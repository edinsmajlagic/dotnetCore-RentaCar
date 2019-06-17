package md58208b91628f75aab8d5bbc48131b8d2a;


public class RatingBarRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CarHireRC.Mobile.Droid.Renderers.RatingBarRenderer, CarHireRC.Mobile.Android", RatingBarRenderer.class, __md_methods);
	}


	public RatingBarRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == RatingBarRenderer.class)
			mono.android.TypeManager.Activate ("CarHireRC.Mobile.Droid.Renderers.RatingBarRenderer, CarHireRC.Mobile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public RatingBarRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == RatingBarRenderer.class)
			mono.android.TypeManager.Activate ("CarHireRC.Mobile.Droid.Renderers.RatingBarRenderer, CarHireRC.Mobile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public RatingBarRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == RatingBarRenderer.class)
			mono.android.TypeManager.Activate ("CarHireRC.Mobile.Droid.Renderers.RatingBarRenderer, CarHireRC.Mobile.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
