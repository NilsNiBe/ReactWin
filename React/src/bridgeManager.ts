import { Bridge } from "./bridge";

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
    if (BridgeManager.bridgeInstances[bridgeName] !== undefined) {
      return BridgeManager.bridgeInstances[bridgeName];
    } else {
      const bridgeMediator: BridgeMediator = (window as any).bridgeMediator;      

      // Generate a bridge class dynamically
      const methodNames = JSON.parse(await bridgeMediator.getBridgeMethods(bridgeName)) as string[];

      const bridgeInstance: any = new Bridge();

      // Lets add all methods
      methodNames.forEach(methodName => {
        // We create a function with the proper name
        bridgeInstance[methodName] = async (...args:any) => {
          const fnResult: string = await bridgeMediator.callMethod(bridgeName, methodName, JSON.stringify(args));

          // Lets deserialize
          const deserializedReturnValue = JSON.parse(fnResult);
          return deserializedReturnValue;
        };
      });

      BridgeManager.bridgeInstances[bridgeName] = bridgeInstance;

      return bridgeInstance as T;
    }
  }
}

export default new BridgeManager();
