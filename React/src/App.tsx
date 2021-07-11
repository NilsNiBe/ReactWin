import React from 'react';
import logo from './logo.svg';
import './App.css';
import bridgeManager from './bridgeManager';
import { CallbackBridge, PropertyBridge } from './bridges';

export interface Bridges {
  callbackBridge: CallbackBridge; 
  propertyBridge: PropertyBridge;
}

const App = () => {
 const [bridges, setBridges] = React.useState<Bridges>();
 const [text, setText] = React.useState("");

  React.useEffect(() => {
    async function loadBridges() {
      const propertyBridge = await bridgeManager.getBridge<PropertyBridge>("propertyBridge")
      const callbackBridge = await bridgeManager.getBridge<CallbackBridge>("callbackBridge")
      propertyBridge.addEventListener("textChanged", (arg:any) => setText(arg.text) )      
      setBridges({callbackBridge, propertyBridge})      
    }
    if ((window as any).bridgeMediator !== undefined) {
      loadBridges();
    }
  }, []);

  function onOutputClicked(){
    if (bridges === undefined) return;
    bridges.callbackBridge.setText(text);
  }

  async function onCallServerClicked(){   
    var res = await window.fetch('api/time')
    const text = await res.json()
    const date = new Date(Date.parse(text))
    setText(date.toLocaleTimeString())
  }

  return (    
      <div className="App">
        <header className="App-header">          
          <img src={logo} className="App-logo" alt="logo" />
          <button onClick={onCallServerClicked}>Call server</button>      
          <input value={text}/>
          <button onClick={onOutputClicked}>To output</button>              
        </header>
      </div>)
}

export default App;
