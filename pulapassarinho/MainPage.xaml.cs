namespace pulapassarinho;

public partial class MainPage : ContentPage
{
	const int gravidade = 1;
	const int tempoentreframes=25;
	bool estamorto = false;
	double LarguraJanela = 0;
	double AlturaJanela = 0;
	int velocidade = 20;
	const int forcaPulo =30;
	const int maxTempoPulando =3;
	bool estaPulando =false;
	int tempoPulando =0;
	const int aberturaMinima =200;


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
			if(estaPulando)
			   AplicaPulo();
			else
			
			AplicarGravidade();
			GerenciaCanos();
			if (VerificaColisao());
			
			

			{
				estamorto=true;
				frameGameOver.IsVisible=true;
				break;
			}

	void AplicaPulo()
	{
		imgPersonagem.TranslationY -=forcaPulo;
		tempoPulando++;
		if(tempoPulando >=maxTempoPulando)
		{
			estaPulando =false;
			tempoPulando=0;
		}
	}

	 void OnGridClicked(object s,TappedEventArgs a)
	 {
		estaPulando =true;
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
		imgMorrinhoCima.TranslationX -=velocidade;
		imgMorrinhoBaixo.TranslationX -=velocidade;
		if(imgMorrinhoBaixo.TranslationX<-LarguraJanela)
		{
			imgMorrinhoBaixo.TranslationX =0;
			imgMorrinhoCima.TranslationX =0;

			var AlturaMax =-100;
			var AlturaMin =-imgMorrinhoBaixo.HeightRequest;
			imgMorrinhoCima.TranslationY =Random.Shared.Next((int)AlturaMin,(int)AlturaMax);
			imgMorrinhoBaixo.TranslationY=imgMorrinhoCima.TranslationY+aberturaMinima +imgMorrinhoBaixo.HeightRequest;
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


