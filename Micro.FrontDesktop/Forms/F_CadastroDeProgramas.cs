using Micro.Aplicacao.DTOs;
using Micro.Aplicacao.Interfaces;
using Micro.FrontDesktop.Model;

namespace Micro.FrontDesktop.Forms
{
    public partial class F_CadastroDeProgramas : Form
    {
        private readonly IProgramaServico _programatService;
        private ProgramaDTO programasDTO = new();
        private ProgramaDto programas = new();

        public F_CadastroDeProgramas(IProgramaServico programatService)
        {
            _programatService = programatService;

            InitializeComponent();

        }

        private void Tempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            { e.Handled = true; }
        }

        private void Potencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            { e.Handled = true; }
        }

        private void B_Novo_Click(object sender, EventArgs e)
        {

            LimpaCampos();
            b_Salvar.Enabled = true;
            b_Cancelar.Enabled = true;
            b_Novo.Enabled = false;
            panel1.Enabled = true;
            t_Nome.Focus();
        }

        public void LimpaCampos()
        {
            programasDTO.Id = 0;
            t_Nome.Clear();
            t_Alimento.Clear();
            t_tempo.Clear();
            t_Potencia.Clear();
            t_instrucoes.Clear();
            t_Aquece.Clear();

            b_Salvar.Text = "Salvar";
            b_Novo.Enabled = true;
            b_Localizar.Enabled = true;
            b_excluir.Enabled = false;
            b_Salvar.Enabled = false;
            b_Cancelar.Enabled = false;
            panel1.Enabled = false;
            t_Nome.Focus();
            
        }

        private void F_CadastroDeProgramas_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
        }

        public async Task<bool> VerificaIgualdadeAsync()
        {
            var confereSimboloAquece = await _programatService.GetVerificaAquecimentoIgual(t_Aquece.Text,programasDTO.Id);
            if (confereSimboloAquece == null)
                return true;
            else
                return false;
        }


        private async void B_Salvar_ClickAsync(object sender, EventArgs e)
        {
            if (!t_Nome.Text.Equals("") && t_Nome.Text.Length > 1)
            {
                if (!t_Alimento.Text.Equals(""))
                {
                    if (!t_tempo.Text.Equals(""))
                    {
                        if (!t_Potencia.Text.Equals(""))
                        {
                                if (!t_Aquece.Text.Equals(""))
                                {
                                    var verifica = await VerificaIgualdadeAsync();
                                    if (verifica)
                                    {
                                        programas.DefinerPotencia(Convert.ToInt32(t_Potencia.Text));
                                        programas.DefineTempo(Convert.ToInt32(t_tempo.Text));


                                        if (programas.ValidaPotencia() && programas.ValidaTempo())
                                        {
                                            try
                                            {
                                                programasDTO.Nome = t_Nome.Text;
                                                programasDTO.Alimento = t_Alimento.Text;
                                                programasDTO.Tempo = Convert.ToInt32(t_tempo.Text);
                                                programasDTO.Potencia = Convert.ToInt32(t_Potencia.Text);
                                                programasDTO.Instrucoes = t_instrucoes.Text;
                                                programasDTO.Aquece = t_Aquece.Text;

                                                if(programasDTO.Id==0)
                                                  await _programatService.Add(programasDTO);
                                                else
                                                    await _programatService.Update(programasDTO);

                                                LimpaCampos();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Falha: " + ex.Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Já existe cadastro com este simbolo de aquecimento");
                                        t_Aquece.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Informe o simbolo de aquecimento");
                                    t_Aquece.Focus();
                                }
               
                        }
                        else
                        {
                            MessageBox.Show("Informe a potencia");
                            t_Potencia.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informe o tempo");
                        t_tempo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Informe o alimento");
                    t_Alimento.Focus();
                }
            }
            else
            {
                MessageBox.Show("Informe o nome e com pelo menos 2 caracteres");
                t_Nome.Focus();
            }
        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            b_Localizar.Enabled = true;
        }

        private void B_Localizar_Click(object sender, EventArgs e)
        {
            F_Localizar f = new(_programatService);
            f.ShowDialog();
            LimpaCampos();

            if (f.programasDTO.Id != 0)
            {
                programasDTO = f.programasDTO;
                t_Nome.Text = f.programasDTO.Nome;
                t_Alimento.Text = f.programasDTO.Alimento;
                t_tempo.Text = f.programasDTO.Tempo.ToString();
                t_Potencia.Text = f.programasDTO.Potencia.ToString();
                t_instrucoes.Text = f.programasDTO.Instrucoes;
                t_Aquece.Text = f.programasDTO.Aquece;

                panel1.Enabled = true;
                b_excluir.Enabled = true;
                b_Cancelar.Enabled = true;
                b_Novo.Enabled = false;
                b_Salvar.Text = "Alterar";
                b_Salvar.Enabled = true;
                t_Nome.Focus();
            }

            f.Dispose();
        }

        private async void B_excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja Realmente excluir?", "Confirmar", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                { 
                    await _programatService.Remove(programasDTO.Id);
                    LimpaCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha: " + ex.Message);
                }
            }
        }
    }
}
