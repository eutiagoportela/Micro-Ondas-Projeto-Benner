using Micro.Aplicacao.DTOs;
using Micro.Aplicacao.Interfaces;
using System.Data;


namespace Micro.FrontDesktop.Forms
{
    public partial class F_Localizar : Form
    {
        private readonly IProgramaServico _programatService;
        public ProgramaDTO programasDTO = new();

        private List<ProgramaDTO> ListaProgramas = new();
        private List<ProgramaDTO> ListaProgramasConsulta = new();

        public F_Localizar(IProgramaServico programatService)
        {
            _programatService = programatService;
            programasDTO.Id = 0;

            InitializeComponent();

        }

        private async void F_Localizar_LoadAsync(object sender, EventArgs e)
        {
            await CarregaProgramasAsync();

                dataGridView1.DataSource = ListaProgramas;
                ColorGridPreProgramas(ListaProgramas);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Refresh();
 
        }

        public async Task CarregaProgramasAsync()
        {
            var Programas = await _programatService.GetProgramasLista();

            foreach (var programa in Programas)
                ListaProgramas.Add(programa);

            ListaProgramasConsulta = ListaProgramas;
        }



        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = e.RowIndex;

            if (linha >= 0)
            {
                var valor = dataGridView1.Rows[linha].Cells[0].Value;
                if (Convert.ToInt32(valor) > 5)//Sao pre cadastrados 5 via migration em InfraData EntidadesConfiguracao/ProgramasConfiguracao
                {
                    programasDTO = ListaProgramasConsulta[linha];
                    Close();
                }
                else
                    MessageBox.Show("Não é possível alterar programa pré cadastrado");
            }
        }

        public void ColorGridPreProgramas(List<ProgramaDTO>  Lista)
        {

            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].Id > 5)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red ;
            }
        }

        private void Consulta_TextChanged(object sender, EventArgs e)
        {
            ListaProgramasConsulta = ListaProgramas.Where(f => f.Nome.ToUpper().Contains(t_consulta.Text.ToUpper()) ).ToList();
            dataGridView1.DataSource = ListaProgramasConsulta;
            ColorGridPreProgramas(ListaProgramasConsulta);
        }
    }
}
