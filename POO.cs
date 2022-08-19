namespace CSharpFormacaoBasica
{
    internal class POO
    {
        // Modificadores definem o nivel de acesso das classes, propriedades e métodos
        // https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/access-modifiers
        // https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

        // public => não tem restrições
        public string objeto_publico;

        // protected internal => pode ser acessado por qualquer código no assembly no qual ele é declarado ou de dentro de um derivado class em outro assembly.
        protected internal string objeto_interno_protegido;

        // protected => pode ser visto quando por uma classe herdada
        protected string objeto_protejido;

        // internal => podem ser acessados do código que faz parte da mesma compilação.
        internal string objeto_interno;

        // private protected => pode ser acessado por tipos derivados do class que são declarados em seu assembly contendo.
        private protected string objeto_privado_protegido;

        // private => o mais restritivo, só pode ser usado dentro da classe onde foi criado
        private string objeto_privado;


        static void Metodo()
        {
            /* 
             
            ---------- MÉTODOS ---------------
             - Ideal que tenham o nome seja um verbo no infinitivo
             - Nome com poucas palavras que define o que o método faz
             - O ideal é que ele faz apenas uma tarefa
             - Cada palavra do nome deve iniciar com letra maiuscula


             --------- NOMENCLATURA ------------
             
             "modificador_de _acesso" "tipo_do_retorno" "nome_do_método" ("tipo_do_parametro" "nome_do_parametro")
             {
                lógica do método

                return "retorno esperado"
             }

            public string CriandoMetodo(string parametro){

               parametro = "novo valor do parametro";

                return parametro;
            }

            Void => Não precisa ter um retorno


           --------- INSTANCIANDO UM OBJETO -----------
            var objeto = new Int32();


            -------- MÉTODO CONSTRUTOR ----------------
             - Esse método carrega o nome da classe e é sempre usado ao instanciar um objeto referenciando a classe
            
                 var objeto = new "construtor";

            - Sempre que um objeto é chamado o método construtor é criado implicitamente pelo dotnet. Esse método
              pode ser modificado conforme sua necessidade.

            - Ao criar um outro método construtor é necessário criar o método construtor padrão, para não dar erro.
                
             - construtor padrão -

            public class Teste {

                public string Nome;
                
                public Teste ()
                {

                }   
            }

            var teste = new Teste();
            teste.Nome = "Meu nome";

            - construtor modificado - 

            public class Teste {

                public string Nome;

                public Teste (string nome){
                    Nome = nome;
                }
            }

            var teste = new Teste("Meu nome");

            --------- PILARES ---------------

            - - - HERANÇA - - -

                - classes que reutilizam o comportamento de classes bases
                - Classe base: membros herdados por outra classe
                - Classe derivada: class que herda os membros
            
            - Só podemos herdar de uma class
            - A herança é definida por :

            public class classeDerivada : classeBase
            {
            }

            - herança de construtor -

            public Aluno()
            {

            }

            public Aluno(string nome) : this() -> herdando do construtor na mesma classe
            {
                Nome = nome;
            }

            public Aluno() : base(nome) -> herdando o construtor da classe base
            {

            }

            - - - ENCAPSULAMENTO - - -

               - Processo de proteger dados de uma classe, para que eles não sejam acessado ou modificados por outra classe

            public decimal Media { get; set;}
                - get -> retorna o valor contido na nossa propriedade
                - set -> atribui um valor para propriedade

            public string Nome { get; private set; } -> privando o metodo set encapsulamos ele, com isso só a classe base irá alterar o valor, usando por exemplo métodos
                                                        e esses métodos se estiverem visiveis podem ser usados na instancia para alterar o valor dessa propriedade;

            - - - POLIMORFISMO - - -

                - Polimorfismo = (grego) Muitas formas
                - Só pode ser alcançado após a Herança

                // um objeto com várias formas

                Aluno aluno = new Aluno(); -> vê todos os métodos da classe base da classe derivada
                Usuario alunoUsuario = new Aluno(); -> só enxerga a classe usuario, mas o tipo ainda é aluno;
                
                // classe base deriva os métodos (virtual), e a classe derivada substitui os métodos (override)
                // virutal -> método da classe base
                // override -> método da classe derivada que substitui o método da classe base
                
                public virtal void Logar()
                {
                    Console.WriteLine("O usuário logou");
                }

                public override void Logar()
                {
                    Console.WriteLine("O aluno logou");
                }
            */
        }
    }
    public class Usuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public Usuario()
        {

        }

        public virtual void Logar()
        {
            Console.WriteLine("O usuário logou.");
        }
    }

    public class Materia
    {
        public string Nome;

        public Materia() { }

        public Materia(string nome)
        {
            Nome = nome;
        }

        public void TestarHeranca()
        {
            var usuario = new Aluno();

            usuario.Logar();

            Usuario usuarioAluno = new Aluno();
        }
    }

    public class Aluno : Usuario
    {
        public int Matricula;
        public decimal Media;
        public List<Materia> Materias;

        public Aluno() : base()
        {
            Materias = new List<Materia>();
        }

        public Aluno(string nome) : this()
        {
            Nome = nome;
        }

        public override void Logar()
        {
            Console.WriteLine("O aluno logou");
        }

        public void CalcularMedia(decimal nota1, decimal nota2, decimal nota3)
        {
            decimal total = nota1 + nota2 + nota3;
            Media = total / 3;
        }

        public string AdicionarMateria(Materia materia)
        {
            var novaMateria = new Materia("Materia inexistete");

            foreach (var mat in Materias)
            {
                if (mat.Nome == materia.Nome)
                    return "Este maéria´já existe";
            }

            Materias.Add(materia);
            return novaMateria.ToString();
        }

    }
}
