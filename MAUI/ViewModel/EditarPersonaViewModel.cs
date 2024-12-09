using BL;
using ENT;
using MAUI.ViewModel.Utilities;

namespace MAUI.ViewModel
{
    [QueryProperty(nameof(Persona), "Persona")]
    public class EditarPersonaViewModel : VMBase
    {
        #region Atributos
        private PersonaConDepartamento? _persona;
        private List<Departamento>? _departamentos;
        private Departamento _departamentoSeleccionado;
        private DelegateCommand _btnVolverCmd;
        private DelegateCommand _btnGuardarCmd;
        #endregion

        #region Propiedades
        public Departamento DepartamentoSeleccionado
        {
            get => _departamentoSeleccionado;
            set
            {
                _departamentoSeleccionado = value;

                if (_persona != null)
                {
                    _persona.IDDepartamento = _departamentoSeleccionado.ID;
                    _persona.NombreDepartamento = _departamentoSeleccionado.Nombre;
                }

                NotifyPropertyChanged(nameof(DepartamentoSeleccionado));
            }
        }
        public PersonaConDepartamento? Persona
        {
            get => _persona;
            set
            {
                _persona = value;
                _departamentoSeleccionado = _departamentos.FirstOrDefault(d => d.ID == _persona?.IDDepartamento) ?? new Departamento();
                NotifyPropertyChanged(nameof(Persona));
                NotifyPropertyChanged(nameof(DepartamentoSeleccionado));
            }
        }
        public List<Departamento>? Departamentos { get => _departamentos; }
        public DelegateCommand BtnVolverCmd { get => _btnVolverCmd; }
        public DelegateCommand BtnGuardarCmd { get => _btnGuardarCmd; }
        #endregion

        #region Constructores
        public EditarPersonaViewModel()
        {
            _departamentoSeleccionado = new Departamento();
            _departamentos = DepartamentoHandlerBL.getDepartamentos();
            _btnGuardarCmd = new DelegateCommand(_btnGuardarCmdExecute);
            _btnVolverCmd = new DelegateCommand(_btnVolverCmdExecute);
        }
        #endregion

        #region Delegates
        private async void _btnGuardarCmdExecute()
        {
            if (_persona != null)
            {
                PersonaHandlerBL.updatePersona(_persona);
                await Shell.Current.GoToAsync("///listaPersonas");
            }
        }
        private async void _btnVolverCmdExecute()
        {
            await Shell.Current.GoToAsync("///listaPersonas");
        }
        #endregion
    }
}
