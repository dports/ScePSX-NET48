namespace ScePSX;

public interface ICoreHandler
{
	void FrameReady(int[] pixels, int width, int height);

	void SamplesReady(byte[] samples);
}
