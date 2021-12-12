package crc64802580bccd059c92;


public class DonorAdapterViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("xdonr.Adapters.DonorAdapterViewHolder, xdonr", DonorAdapterViewHolder.class, __md_methods);
	}


	public DonorAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == DonorAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("xdonr.Adapters.DonorAdapterViewHolder, xdonr", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
