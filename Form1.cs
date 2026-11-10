using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlimentacaoSaudavel
{
    public class Form1 : Form
    {
        TabControl abas;
        TabPage abaPrato;
        TabPage abaDicas;
        TabPage abaQuiz;

        string[] proteinas = { "Frango grelhado", "Ovo cozido", "Feijão", "Salsicha", "Carne frita" };
        int[] pontosProteinas = { 2, 2, 1, 0, 0 };

        string[] carboidratos = { "Arroz integral", "Arroz branco", "Macarrão integral", "Batata frita", "Pão branco" };
        int[] pontosCarboidratos = { 2, 1, 2, 0, 0 };

        string[] vegetais = { "Salada verde", "Legumes no vapor", "Nenhum vegetal" };
        int[] pontosVegetais = { 2, 2, 0 };

        string[] bebidas = { "Água", "Suco natural", "Refrigerante", "Refrigerante diet/zero" };
        int[] pontosBebidas = { 2, 2, 0, 1 };


        Button[] botoesProteina = new Button[5];
        Button[] botoesCarbo = new Button[5];
        Button[] botoesVegetal = new Button[3];
        Button[] botoesBebida = new Button[4];


        int pontosProteina = -1;
        int pontosCarbo = -1;
        int pontosVegetal = -1;
        int pontosBebida = -1;

        Label lblTotal;
        Label lblMensagem;
        ProgressBar barra;

        string[] dicas = {
            "Beba bastante água durante o dia, evitando refrigerantes.",
            "Prefira alimentos naturais a alimentos ultraprocessados.",
            "Inclua frutas e vegetais em pelo menos duas refeições por dia.",
            "Evite pular refeições, principalmente o café da manhã.",
            "Modere o consumo de açúcar e frituras.",
            "Leia os rótulos dos alimentos antes de comprar.",
            "Coma devagar e perceba quando já está satisfeito."
        };

        string[] perguntas = {
            "Qual desses alimentos é ultraprocessado?",
            "Qual é a bebida mais recomendada para se hidratar?",
            "Qual grupo de alimentos tem mais fibras?",
            "Pular refeições faz bem para a saúde?",
            "O que devemos olhar antes de comprar um alimento industrializado?"
        };


        string[,] opcoes = {
            { "Maçã", "Salgadinho de pacote", "Feijão", "Ovo" },
            { "Refrigerante", "Água", "Suco artificial", "Energético" },
            { "Frituras", "Doces", "Vegetais e frutas", "Refrigerantes" },
            { "Sim, sempre", "Não, o ideal é ter uma rotina", "Sim, à noite", "Não importa" },
            { "A cor da embalagem", "O rótulo com os ingredientes", "Só o preço", "Só a marca" }
        };


        int[] respostas = { 1, 1, 2, 1, 1 };

        int perguntaAtual = 0;
        int acertos = 0;
        bool respondeu = false;

        Label lblNumero;
        Label lblPergunta;
        Label lblFeedback;
        Button[] botoesOpcao = new Button[4];
        Button btnProximo;
        Button btnReiniciar;

        public Form1()
        {
            Text = "Alimentação Saudável";
            ClientSize = new Size(920, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            Font = new Font("Arial", 10);


            Label titulo = new Label();
            titulo.Text = "Alimentação saudável começa com escolhas conscientes";
            titulo.Font = new Font("Arial", 16, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.BackColor = Color.DarkGreen;
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            titulo.Dock = DockStyle.Top;
            titulo.Height = 70;

            abas = new TabControl();
            abas.Dock = DockStyle.Fill;

            abaPrato = new TabPage("Montar prato");
            abaDicas = new TabPage("Dicas");
            abaQuiz = new TabPage("Quiz");
            abas.TabPages.Add(abaPrato);
            abas.TabPages.Add(abaDicas);
            abas.TabPages.Add(abaQuiz);

            Controls.Add(abas);
            Controls.Add(titulo);
            abas.BringToFront();

            CriarAbaPrato();
            CriarAbaDicas();
            CriarAbaQuiz();
        }

        void CriarAbaPrato()
        {
            Label t = new Label();
            t.Text = "Monte o seu prato";
            t.Font = new Font("Arial", 16, FontStyle.Bold);
            t.Location = new Point(20, 15);
            t.AutoSize = true;
            abaPrato.Controls.Add(t);


            Label l1 = new Label();
            l1.Text = "Proteína";
            l1.Font = new Font("Arial", 11, FontStyle.Bold);
            l1.Location = new Point(20, 70);
            l1.AutoSize = true;
            abaPrato.Controls.Add(l1);

            for (int i = 0; i < proteinas.Length; i++)
            {
                Button b = new Button();
                b.Text = proteinas[i];
                b.Tag = pontosProteinas[i];
                b.Size = new Size(120, 50);
                b.Location = new Point(20 + i * 125, 95);
                b.BackColor = Color.White;
                b.Click += new EventHandler(ClickProteina);
                botoesProteina[i] = b;
                abaPrato.Controls.Add(b);
            }


            Label l2 = new Label();
            l2.Text = "Carboidrato";
            l2.Font = new Font("Arial", 11, FontStyle.Bold);
            l2.Location = new Point(20, 165);
            l2.AutoSize = true;
            abaPrato.Controls.Add(l2);

            for (int i = 0; i < carboidratos.Length; i++)
            {
                Button b = new Button();
                b.Text = carboidratos[i];
                b.Tag = pontosCarboidratos[i];
                b.Size = new Size(120, 50);
                b.Location = new Point(20 + i * 125, 190);
                b.BackColor = Color.White;
                b.Click += new EventHandler(ClickCarbo);
                botoesCarbo[i] = b;
                abaPrato.Controls.Add(b);
            }


            Label l3 = new Label();
            l3.Text = "Vegetal";
            l3.Font = new Font("Arial", 11, FontStyle.Bold);
            l3.Location = new Point(20, 260);
            l3.AutoSize = true;
            abaPrato.Controls.Add(l3);

            for (int i = 0; i < vegetais.Length; i++)
            {
                Button b = new Button();
                b.Text = vegetais[i];
                b.Tag = pontosVegetais[i];
                b.Size = new Size(120, 50);
                b.Location = new Point(20 + i * 125, 285);
                b.BackColor = Color.White;
                b.Click += new EventHandler(ClickVegetal);
                botoesVegetal[i] = b;
                abaPrato.Controls.Add(b);
            }


            Label l4 = new Label();
            l4.Text = "Bebida";
            l4.Font = new Font("Arial", 11, FontStyle.Bold);
            l4.Location = new Point(20, 355);
            l4.AutoSize = true;
            abaPrato.Controls.Add(l4);

            for (int i = 0; i < bebidas.Length; i++)
            {
                Button b = new Button();
                b.Text = bebidas[i];
                b.Tag = pontosBebidas[i];
                b.Size = new Size(120, 50);
                b.Location = new Point(20 + i * 125, 380);
                b.BackColor = Color.White;
                b.Click += new EventHandler(ClickBebida);
                botoesBebida[i] = b;
                abaPrato.Controls.Add(b);
            }


            Label lp = new Label();
            lp.Text = "Pontuação";
            lp.Font = new Font("Arial", 11, FontStyle.Bold);
            lp.Location = new Point(690, 70);
            lp.AutoSize = true;
            abaPrato.Controls.Add(lp);

            lblTotal = new Label();
            lblTotal.Text = "0 / 8";
            lblTotal.Font = new Font("Arial", 28, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(690, 95);
            lblTotal.Size = new Size(190, 55);
            abaPrato.Controls.Add(lblTotal);

            barra = new ProgressBar();
            barra.Location = new Point(690, 160);
            barra.Size = new Size(190, 18);
            barra.Maximum = 8;
            abaPrato.Controls.Add(barra);

            lblMensagem = new Label();
            lblMensagem.Location = new Point(690, 195);
            lblMensagem.Size = new Size(190, 90);
            abaPrato.Controls.Add(lblMensagem);

            Button btnLimpar = new Button();
            btnLimpar.Text = "Recomeçar prato";
            btnLimpar.Location = new Point(690, 310);
            btnLimpar.Size = new Size(190, 40);
            btnLimpar.Click += new EventHandler(ClickLimpar);
            abaPrato.Controls.Add(btnLimpar);

            CalcularTotal();
        }

        void ClickProteina(object sender, EventArgs e)
        {
            Button clicado = (Button)sender;
            pontosProteina = Convert.ToInt32(clicado.Tag);

            for (int i = 0; i < botoesProteina.Length; i++)
            {
                botoesProteina[i].BackColor = Color.White;
            }
            clicado.BackColor = Color.LightGreen;

            CalcularTotal();
        }

        void ClickCarbo(object sender, EventArgs e)
        {
            Button clicado = (Button)sender;
            pontosCarbo = Convert.ToInt32(clicado.Tag);

            for (int i = 0; i < botoesCarbo.Length; i++)
            {
                botoesCarbo[i].BackColor = Color.White;
            }
            clicado.BackColor = Color.LightGreen;

            CalcularTotal();
        }


        void ClickVegetal(object sender, EventArgs e)
        {
            Button clicado = (Button)sender;
            pontosVegetal = Convert.ToInt32(clicado.Tag);

            for (int i = 0; i < botoesVegetal.Length; i++)
            {
                botoesVegetal[i].BackColor = Color.White;
            }
            clicado.BackColor = Color.LightGreen;

            CalcularTotal();
        }


        void ClickBebida(object sender, EventArgs e)
        {
            Button clicado = (Button)sender;
            pontosBebida = Convert.ToInt32(clicado.Tag);

            for (int i = 0; i < botoesBebida.Length; i++)
            {
                botoesBebida[i].BackColor = Color.White;
            }
            clicado.BackColor = Color.LightGreen;

            CalcularTotal();
        }


        void ClickLimpar(object sender, EventArgs e)
        {
            pontosProteina = -1;
            pontosCarbo = -1;
            pontosVegetal = -1;
            pontosBebida = -1;

            for (int i = 0; i < botoesProteina.Length; i++)
            {
                botoesProteina[i].BackColor = Color.White;
            }
            for (int i = 0; i < botoesCarbo.Length; i++)
            {
                botoesCarbo[i].BackColor = Color.White;
            }
            for (int i = 0; i < botoesVegetal.Length; i++)
            {
                botoesVegetal[i].BackColor = Color.White;
            }
            for (int i = 0; i < botoesBebida.Length; i++)
            {
                botoesBebida[i].BackColor = Color.White;
            }

            CalcularTotal();
        }


        void CalcularTotal()
        {
            int total = 0;
            int escolhidos = 0;

            if (pontosProteina >= 0)
            {
                total = total + pontosProteina;
                escolhidos++;
            }
            if (pontosCarbo >= 0)
            {
                total = total + pontosCarbo;
                escolhidos++;
            }
            if (pontosVegetal >= 0)
            {
                total = total + pontosVegetal;
                escolhidos++;
            }
            if (pontosBebida >= 0)
            {
                total = total + pontosBebida;
                escolhidos++;
            }

            lblTotal.Text = total + " / 8";
            barra.Value = total;

            if (escolhidos < 4)
            {
                lblMensagem.Text = "Escolha um item de cada categoria para ver o resultado.";
                lblMensagem.BackColor = Color.WhiteSmoke;
            }
            else if (total >= 7)
            {
                lblMensagem.Text = "Excelente! Seu prato está muito saudável.";
                lblMensagem.BackColor = Color.LightGreen;
            }
            else if (total >= 4)
            {
                lblMensagem.Text = "Bom! Mas ainda dá para melhorar.";
                lblMensagem.BackColor = Color.LightYellow;
            }
            else
            {
                lblMensagem.Text = "Atenção! Escolha mais alimentos naturais.";
                lblMensagem.BackColor = Color.LightSalmon;
            }
        }


        void CriarAbaDicas()
        {
            Label t = new Label();
            t.Text = "Dicas de alimentação saudável";
            t.Font = new Font("Arial", 16, FontStyle.Bold);
            t.Location = new Point(20, 15);
            t.AutoSize = true;
            abaDicas.Controls.Add(t);

            string texto = "";
            for (int i = 0; i < dicas.Length; i++)
            {
                texto = texto + (i + 1) + ". " + dicas[i] + "\n\n";
            }

            Label lista = new Label();
            lista.Text = texto;
            lista.Font = new Font("Arial", 12);
            lista.Location = new Point(20, 70);
            lista.Size = new Size(850, 420);
            abaDicas.Controls.Add(lista);
        }


        void CriarAbaQuiz()
        {
            Label t = new Label();
            t.Text = "Quiz";
            t.Font = new Font("Arial", 16, FontStyle.Bold);
            t.Location = new Point(20, 15);
            t.AutoSize = true;
            abaQuiz.Controls.Add(t);

            lblNumero = new Label();
            lblNumero.Location = new Point(20, 60);
            lblNumero.Size = new Size(840, 25);
            abaQuiz.Controls.Add(lblNumero);

            lblPergunta = new Label();
            lblPergunta.Font = new Font("Arial", 14, FontStyle.Bold);
            lblPergunta.Location = new Point(20, 95);
            lblPergunta.Size = new Size(840, 55);
            abaQuiz.Controls.Add(lblPergunta);


            for (int i = 0; i < 4; i++)
            {
                Button b = new Button();
                b.Size = new Size(840, 45);
                b.Location = new Point(20, 160 + i * 55);
                b.TextAlign = ContentAlignment.MiddleLeft;
                b.BackColor = Color.White;
                b.Click += new EventHandler(ClickOpcao);
                botoesOpcao[i] = b;
                abaQuiz.Controls.Add(b);
            }

            lblFeedback = new Label();
            lblFeedback.Font = new Font("Arial", 11, FontStyle.Bold);
            lblFeedback.Location = new Point(20, 390);
            lblFeedback.Size = new Size(840, 50);
            abaQuiz.Controls.Add(lblFeedback);

            btnProximo = new Button();
            btnProximo.Text = "Próxima";
            btnProximo.Location = new Point(20, 450);
            btnProximo.Size = new Size(180, 40);
            btnProximo.Click += new EventHandler(ClickProximo);
            abaQuiz.Controls.Add(btnProximo);

            btnReiniciar = new Button();
            btnReiniciar.Text = "Refazer o quiz";
            btnReiniciar.Location = new Point(20, 450);
            btnReiniciar.Size = new Size(180, 40);
            btnReiniciar.Click += new EventHandler(ClickReiniciar);
            abaQuiz.Controls.Add(btnReiniciar);

            MostrarPergunta();
        }


        void MostrarPergunta()
        {
            respondeu = false;

            lblNumero.Text = "Pergunta " + (perguntaAtual + 1) + " de " + perguntas.Length;
            lblPergunta.Text = perguntas[perguntaAtual];
            lblFeedback.Text = "";

            for (int i = 0; i < 4; i++)
            {
                botoesOpcao[i].Text = opcoes[perguntaAtual, i];
                botoesOpcao[i].BackColor = Color.White;
                botoesOpcao[i].Visible = true;
            }

            btnProximo.Visible = false;
            btnReiniciar.Visible = false;
        }

        void ClickOpcao(object sender, EventArgs e)
        {
            if (respondeu == true)
            {
                return; 
            }
            respondeu = true;


            int escolhida = 0;
            for (int i = 0; i < 4; i++)
            {
                if (sender == botoesOpcao[i])
                {
                    escolhida = i;
                }
            }

            int certa = respostas[perguntaAtual];

            if (escolhida == certa)
            {
                acertos++;
                botoesOpcao[escolhida].BackColor = Color.LightGreen;
                lblFeedback.Text = "Resposta correta!";
            }
            else
            {
                botoesOpcao[escolhida].BackColor = Color.LightSalmon;
                botoesOpcao[certa].BackColor = Color.LightGreen;
                lblFeedback.Text = "Errou! A resposta certa era: " + opcoes[perguntaAtual, certa];
            }

            btnProximo.Visible = true;
        }


        void ClickProximo(object sender, EventArgs e)
        {
            perguntaAtual++;

            if (perguntaAtual < perguntas.Length)
            {
                MostrarPergunta();
            }
            else
            {
                MostrarResultado();
            }
        }


        void MostrarResultado()
        {
            for (int i = 0; i < 4; i++)
            {
                botoesOpcao[i].Visible = false;
            }
            btnProximo.Visible = false;

            lblNumero.Text = "Fim do quiz!";
            lblPergunta.Text = "Você acertou " + acertos + " de " + perguntas.Length + " perguntas.";

            int porcentagem = acertos * 100 / perguntas.Length;

            if (porcentagem >= 80)
            {
                lblFeedback.Text = "Parabéns! Você entende bem de alimentação saudável.";
            }
            else if (porcentagem >= 50)
            {
                lblFeedback.Text = "Bom trabalho! Mas ainda dá para aprender mais.";
            }
            else
            {
                lblFeedback.Text = "Vale a pena estudar mais sobre o assunto. Tente de novo!";
            }

            btnReiniciar.Visible = true;
        }

        void ClickReiniciar(object sender, EventArgs e)
        {
            perguntaAtual = 0;
            acertos = 0;
            MostrarPergunta();
        }
    }
}
