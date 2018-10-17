package md526e8c661f84bac6a1a21d64c806a4855;


public class WiFiConnectionService
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("MANET_DTN_Mobile.Droid.Classes.WiFiConnectionService, MANET_DTN_Mobile.Droid", WiFiConnectionService.class, __md_methods);
	}


	public WiFiConnectionService ()
	{
		super ();
		if (getClass () == WiFiConnectionService.class)
			mono.android.TypeManager.Activate ("MANET_DTN_Mobile.Droid.Classes.WiFiConnectionService, MANET_DTN_Mobile.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
