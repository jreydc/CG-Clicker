using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class WalletConnector : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Send(string msg);

    public TextMeshPro buttonText;

    string address= "https://link.bladewallet.io/?link=https://api.bladewallet.io/mobile/profile/attachAccount?dApp_code%3Dcode%26dApp_nonce%3Dnonce_token_value&apn=org.bladelabs.wallet";

    public void ConnectWallet(){
        Send(address);
    }

    public void SetAddress(string newAddress){
        if(address==""){
            address = newAddress;
            buttonText.text = address;
        }
    }
}
