import React from 'react';
import logo from './logo.svg';
import './App.css';
import bridgeManager from './bridgeManager';
import { CallbackBridge } from './bridges';

export interface Bridges {
  callbackBridge: CallbackBridge; 
}

const App = () => {
 const [bridges, setBridges] = React.useState<Bridges>();

  React.useEffect(() => {
    async function loadBridges() {
      const callbackBridge = await bridgeManager.getBridge<CallbackBridge>("callbackBridge") 
      setBridges({callbackBridge})      
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
          <input onChange={e => inputChanged(e.target.value)}/>
          </>)}   
       
          
        </header>
      </div>)
    

}

export default App;
