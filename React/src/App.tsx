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
 const input = React.useRef<HTMLInputElement>(null);

  React.useEffect(() => {
    async function loadBridges() {
      const propertyBridge = await bridgeManager.getBridge<PropertyBridge>("propertyBridge")
      const callbackBridge = await bridgeManager.getBridge<CallbackBridge>("callbackBridge")
      propertyBridge.addEventListener("textChanged", (arg:any) => {if (input.current !== null) input.current.value = arg.text} )      
      setBridges({callbackBridge, propertyBridge})      
    }
    if ((window as any).bridgeMediator !== undefined) {
      loadBridges();
    }
  }, []);

function inputChanged(text: string) {
  if (bridges === undefined) return;
  bridges.callbackBridge.setText(text);
}
  return (    
      <div className="App">
        <header className="App-header">          
          <img src={logo} className="App-logo" alt="logo" />
          {bridges !== undefined && (<>           
          <input ref={input} onChange={e => inputChanged(e.target.value)}/>
          </>)}          
        </header>
      </div>)
    

}

export default App;
