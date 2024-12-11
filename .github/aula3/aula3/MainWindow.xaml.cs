using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aula3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Função associada ao click do botão adicionar
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            //1-> obter os valores das textbox
            string valor1 = txtValor1.Text;
            string valor2 = txtValor2.Text;
            
            //1.1-> converter para inteiros
            //A classe Convert permite converter valores
            int valor1Int = Convert.ToInt32(valor1);
            int valor2Int = Convert.ToInt32(valor2);

            //2-> somar
            //concatenar
            string resultado = valor1 + valor2;
            int resultadoInt = valor1Int + valor2Int;

            //3-> mostrar o resultado
            string resultadoString = Convert.ToString(resultadoInt);

            //Utilizar o método tostring para converter
            //ja está implementado
            txtResultado.Text = resultadoInt.ToString();

            //4-> adicionar os resultados nas listas

            //combox
            cbResultados.Items.Add(resultadoString);
            //ListBox
            lbResultados.Items.Add(resultadoString);

            //podemos ter varias colunas
            listViewResultados.Items.Add(resultadoString);
            
            // arvore
            treeViewResultados.Items.Add(resultadoString);
             
            //criar um item treeview
            //criar objeto do tipo treeview

            TreeViewItem pai = new TreeViewItem();
            // criar uma string com o formato que queremos
            pai.Header = String.Format("{0} + {1}", valor1, valor2);

            TreeViewItem filho = new TreeViewItem();
            // criar uma string com o formato que queremos
            filho.Header = resultadoString;

            pai.Items.Add(filho);

            treeViewResultados.Items.Add(pai);

        }
    }
}