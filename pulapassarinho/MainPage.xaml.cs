namespace pulapassarinho;

public partial class MainPage : ContentPage
{
	const int gravidade = 1;
	const int tempoentreframes=25;
	bool estamorto = false;
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
		while (!estamorto)
		{
			AplicarGravidade();
			GerenciaCanos();
			if (VerificaColisao());

			{
				estamorto=true;
				frameGameOver.IsVisible=true;
				break;
			}
			
		}
		await Task.Delay(tempoentreframes);
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
			imgMorrinhoBaixo.TranslationX =20;
			ImgMorrinhoCima.TranslationX =20;
		}
	}
	
	bool VerificaColisaoTeto()
	{
		var minY =-AlturaJanela/2;
		if(imgPersonagem.TranslationY <=minY)
		    return true;
		else
		    return false;
	}
	bool VerificaColisaoChao()
	{
		var maxY=AlturaJanela/2 - imgMorrinhoBaixo.HeightRequest;
		if(imgPersonagem.TranslationY >=maxY)
		   return true;
		else
		    return false;

	}
	bool VerificaColisao()
	{
		if(!estamorto)
		{
			if(VerificaColisaoTeto() ||
			   VerificaColisaoChao());
		}
		{
		return true;
		
		}
	}
	
		
	}


