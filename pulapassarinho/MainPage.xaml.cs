namespace pulapassarinho;

public partial class MainPage : ContentPage
{
	const int gravidade = 1;
	const int tempoentreframes=25;
	bool estamorto = true;
	double LarguraJanela = 0;
	double AlturaJanela = 0;
	int velocidade = 20;


	public MainPage()
	{
		InitializeComponent();
	}
    void AplicarGravidade()
	{
		imgPersonagem.TranslationY +=gravidade;
	}

	async Task Desenha()
	{
		while (estamorto)
		{
			AplicarGravidade();
			await Task.Delay(tempoentreframes);
			GerenciaCanos();
		}
	}
	
	void onGameOverClicked(object s, TappedEventArgs e)
	{
		frameGameOver.IsVisible = false;
		Inicializar();
		Desenha();
	}

	void Inicializar()
	{
		estamorto = false;
		imgPersonagem.TranslationY = 0;
	}

    protected void OnSizeAllocated (double w, double h)
	{
		base.OnSizeAllocated(w,h);
		LarguraJanela = w;
		AlturaJanela = h;
	}
	void GerenciaCanos()
	{
		ImgMorrinhoCima.TranslationX -=velocidade;
		imgMorrinhoBaixo.TranslationX -=velocidade;
		if(imgMorrinhoBaixo.TranslationX<-LarguraJanela)
		{
			imgMorrinhoBaixo.TranslationX =0;
			ImgMorrinhoCima.TranslationX =0;
		}
	}
}

