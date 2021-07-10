interface BridgeMediator {
  callMethod(bridgeName: string, methodName: string, args: string): string;
  getBridgeMethods(bridgeName: string): string;
}

class BridgeManager {
  // We always return the same instances, this is needed so we can handle events in a centralized way
  static bridgeInstances = {} as any;

  constructor() {
    (window as any).bridgeManager = this;
  }

  async getBridge<T>(bridgeName: string): Promise<T> {
    // Do we have an existing?
    debugger;
    if (BridgeManager.bridgeInstances[bridgeName] !== undefined) {
      return BridgeManager.bridgeInstances[bridgeName];
    } else {
      const bridgeMediator: BridgeMediator = (window as any).bridgeMediator;
      console.log(bridgeMediator)

      // Generate a bridge class dynamically
      const methodNames = JSON.parse(await bridgeMediator.getBridgeMethods(bridgeName)) as string[];

      const bridgeInstance: any = new Bridge();

      // Lets add all methods
      methodNames.forEach(methodName => {
        // We create a function with the proper name
        bridgeInstance[methodName] = async (...args:any) => {
          let fnResult: string = await bridgeMediator.callMethod(bridgeName, methodName, JSON.stringify(args));

          // Lets deserialize
          let deserializedReturnValue = JSON.parse(fnResult);
          return deserializedReturnValue;
        };
      });

      BridgeManager.bridgeInstances[bridgeName] = bridgeInstance;

      return bridgeInstance as T;
    }
  }
}

export class Bridge {
  private triggerEvent(eventName: string, args: any) {
    let listeners = this.getEventListeners(eventName);

    listeners.forEach(listener => {
      listener(args);
    });
  }

  private _eventListeners = {} as any;

  getEventListeners(eventName: string): any[] {
    if (this._eventListeners[eventName] === undefined) {
      return [];
    } else {
      return this._eventListeners[eventName];
    }
  }

  addEventListener(eventName: string, delegate: any) {
    if (this._eventListeners[eventName] === undefined) {
      this._eventListeners[eventName] = [delegate];
    } else {
      this._eventListeners[eventName].push(delegate);
    }
  }
}

export default new BridgeManager();
