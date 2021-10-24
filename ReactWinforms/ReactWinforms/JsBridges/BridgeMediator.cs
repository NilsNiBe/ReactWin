using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ReactWinforms.JsBridges
{
  public class BridgeMediator
  {
    private readonly Dictionary<string, object> m_Bridges = new Dictionary<string, object>();
    private readonly ChromiumWebBrowser m_Browser;

    public BridgeMediator(ChromiumWebBrowser browser, IEnumerable<object> bridges)
    {
      m_Browser = browser;

      foreach (var bridge in bridges) {
        string bridgeName = StringService.ConvertToCamelCase(bridge.GetType().Name);
        m_Bridges.Add(bridgeName, bridge);
        HookUpEventListeners(bridgeName, bridge);
      }
    }

    private void HookUpEventListeners(string bridgeName, object instance)
    {
      var eventInfos = instance.GetType().GetEvents();

      foreach (var eventInfo in eventInfos) {
        if (eventInfo.EventHandlerType == typeof(Action)) {
          eventInfo.AddEventHandler(
            instance, new Action(() => HandleEvent(bridgeName, eventInfo.Name, null)));
        } else {
          eventInfo.AddEventHandler(instance
            , new Action<object>(arg => HandleEvent(bridgeName, eventInfo.Name, arg)));
        }
      }
    }

    private void HandleEvent(string bridgeName, string eventName, object args)
    {
      var argsJson = JsonConvert.SerializeObject(args, new JsonSerializerSettings {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });

      argsJson = HttpUtility.JavaScriptStringEncode(argsJson);

      m_Browser.ExecuteScriptAsync($"window.bridgeManager.getBridge('{bridgeName}').then(" +
        "bridge => bridge.triggerEvent(" +
        "'{StringService.ConvertToCamelCase(eventName)}', JSON.parse('{argsJson}')))");
    }

    /// <summary>
    /// 
    /// </summary>
    public string CallMethod(string bridgeName, string methodName, string arguments)
    {
      var realArguments = JsonConvert.DeserializeObject<object[]>(arguments);

      var bridgeObject = m_Bridges[bridgeName];
      var mi = bridgeObject.GetType().GetMethod(StringService.ConvertToTitleCase(methodName));
      object result = mi.Invoke(bridgeObject, realArguments);

      return JsonConvert.SerializeObject(result, new JsonSerializerSettings {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });
    }

    /// <summary>
    /// 
    /// </summary>
    public string GetBridgeMethods(string bridgeName)
    {
      var bridgeObject = m_Bridges[bridgeName];

      // Return method names
      var methods = bridgeObject.GetType().GetMethods().Select(mi => mi.Name)
        .Select(methodName => StringService.ConvertToCamelCase(methodName)).ToList();

      return JsonConvert.SerializeObject(methods, new JsonSerializerSettings {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });
    }
  }
}
