using Micro.Aplicacao.DTOs;
using Micro.Aplicacao.Interfaces;
using Micro.FrontDesktop.Forms;
using Micro.FrontDesktop.Model;

namespace Micro.FrontDesktop
{
    public partial class F_Principal : Form
    {
        public string MsgProcessamento = "";
        private ProgramaDto programas = new();
        private readonly IProgramaServico _programatService;
        private List<ProgramaDTO> ListaProgramas = new();

        public F_Principal(IProgramaServico programatService)
        {
            _programatService = programatService;
            InitializeComponent();
        }

        public async Task CarregaProgramasAsync()
        {
            var Programas = await _programatService.GetProgramasLista().ConfigureAwait(false);
            ListaProgramas.Clear();
            foreach (var programa in Programas)
                ListaProgramas.Add(programa);
        }

        private void Tela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            { e.Handled = true; }
        }

        private void Potencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            { e.Handled = true; }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            AtualizaMsgProcessamento();
            if (programas.Tempo > 0)
                programas.DefineTempo(programas.Tempo - 1);
            else
                Finaliza();

            this.Refresh();
        }

        private void B_Inicio_Click(object sender, EventArgs e)
        {

            if (!Rb_Nivel1.Checked && cb_Programas.SelectedIndex < 0)
                MessageBox.Show("Selecione primeiro o programa");
            else
            {
                if (timer1.Enabled)
                {
                    if (Rb_Nivel1.Checked)
                        programas.DefineTempo(programas.Tempo + 30);
                }
                else
                    if (programas.Tempo > 0)
                    timer1.Enabled = true;
                else
                {
                    if (t_tempo.Text.Equals(""))
                    {
                        programas.DefineTempo(30);
                        programas.DefinerPotencia(10);
                    }
                    else
                    {
                        programas.DefineTempo(Convert.ToInt32(t_tempo.Text));
                        if (!t_Potencia.Text.Equals(""))
                            programas.DefinerPotencia(Convert.ToInt32(t_Potencia.Text));
                        else
                            programas.DefinerPotencia(10);
                    }


                    if (!Rb_Nivel1.Checked)
                        Inicio();
                    else
                    if (programas.ValidaPotencia() && programas.ValidaTempo())
                        Inicio();

                }
            }
        }

        public void AtualizaMsgProcessamento()
        {
            string auxAquece = ".", aux = "";

            if (!Rb_Nivel1.Checked)
                auxAquece = ListaProgramas[cb_Programas.SelectedIndex].Aquece;

            if (programas.Tempo > 0)
            {
                for (int i = 0; i < programas.Potencia; i++)
                {
                    aux += auxAquece;
                }
                MsgProcessamento += aux + " ";
                t_MsgProcessando.Text = MsgProcessamento;
            }
            else
            {
                t_MsgProcessando.Text = MsgProcessamento + " Aquecimento concluído";
                this.Refresh();
                Thread.Sleep(2000);
            }

            l_Processando.Text = "Processando: " + TimeSpan.FromSeconds(programas.Tempo).Minutes + ":" + TimeSpan.FromSeconds(programas.Tempo).Seconds;

        }

        private void B_pausaCancela_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                if (timer1.Enabled == false)
                Finaliza();
        }

        public void Inicio()
        {
            groupBox1.Visible = false;
            t_Potencia.Enabled = false;
            l_potencia.Enabled = false;
            t_Potencia.Visible = false;
            t_tempo.Enabled = false;
            l_potencia.Visible = false;
            t_tempo.Visible = false;
            l_tempo.Visible = false;
            timer1.Enabled = true;

            if (!Rb_Nivel1.Checked)
            {
                l_cbProgramas.Visible = false;
                cb_Programas.Visible = false;
                lb_Instrucoes.Visible = false;
            }

            l_Processando.Visible = true;
            t_MsgProcessando.Visible = true;

            if (timer1.Enabled == false)
                timer1.Enabled = true;


        }

        public void Finaliza()
        {
            if (timer1.Enabled)
                timer1.Enabled = false;

            programas.DefineTempo(0);
            programas.DefinerPotencia(0);
            MsgProcessamento = "";

            groupBox1.Visible = true;
            t_Potencia.Enabled = true;
            l_potencia.Enabled = true;
            l_potencia.Visible = true;
            t_tempo.Enabled = true;
            t_Potencia.Visible = true;
            t_tempo.Visible = true;
            l_tempo.Visible = true;

            if (!Rb_Nivel1.Checked)
            {
                l_cbProgramas.Visible = true;
                cb_Programas.Visible = true;
                lb_Instrucoes.Visible = true;

                t_Potencia.Enabled = false;
                t_tempo.Enabled = false;
            }

            l_Processando.Visible = false;
            t_MsgProcessando.Visible = false;
            t_MsgProcessando.Clear();
            l_Processando.Text = "Processando";
            t_Potencia.Clear();
            t_tempo.Clear();
            cb_Programas.SelectedIndex = -1;
            lb_Instrucoes.Text = "Instruções:";

        }

        private void Rb_Nivel1_CheckedChanged(object sender, EventArgs e)
        {
            Finaliza();
            if (Rb_Nivel1.Checked)
            {
                cb_Programas.Visible = false;
                l_cbProgramas.Visible = false;
                lb_Instrucoes.Visible = false;
            }
            else
            {
                cb_Programas.Visible = true;
                l_cbProgramas.Visible = true;
                lb_Instrucoes.Visible = true;

                t_tempo.Enabled = false;
                t_Potencia.Enabled = false;
            }
        }

        private void Cb_Programas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posicao = cb_Programas.SelectedIndex;
            if (posicao >= 0)
            {
                t_tempo.Text = ListaProgramas[posicao].Tempo.ToString();
                t_Potencia.Text = ListaProgramas[posicao].Potencia.ToString();
                lb_Instrucoes.Text = "Instruções: \n" + ListaProgramas[posicao].Instrucoes.ToString();

                if(posicao<5)
                    lb_Instrucoes.Font = new Font(lb_Instrucoes.Font, FontStyle.Italic);  
                else
                    lb_Instrucoes.Font = new Font(lb_Instrucoes.Font, FontStyle.Regular);
            }
        }

        private void RbNivel3_CheckedChanged(object sender, EventArgs e)
        {
            Finaliza();
            if (RbNivel3.Checked)
                menuStrip1.Visible = true;
            else
                menuStrip1.Visible = false;
        }


        private void Nivel1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CadastroDeProgramas f = new(_programatService);
            f.ShowDialog();
            f.Dispose();

            CarregaCombo();
            
        }

        private void  F_Principal_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            CarregaCombo();
        }
       
        public async void CarregaCombo()
        {
            await CarregaProgramasAsync();

            cb_Programas.Items.Clear();
            for (int i=0; i<ListaProgramas.Count; i++)
                cb_Programas.Items.Add(ListaProgramas[i].Alimento);

        }
    }
}