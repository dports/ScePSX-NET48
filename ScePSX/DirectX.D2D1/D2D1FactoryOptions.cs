namespace DirectX.D2D1;

public struct D2D1FactoryOptions
{
	public D2D1DebugLevel debugLevel;

	public D2D1FactoryOptions(D2D1DebugLevel debugLevel)
	{
		this.debugLevel = debugLevel;
	}
}
