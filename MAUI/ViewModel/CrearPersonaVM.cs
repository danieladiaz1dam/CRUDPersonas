using BL;
using ENT;
using MAUI.ViewModel.Utilities;

namespace MAUI.ViewModel
{
    public class CrearPersonaVM : VMBase
    {
        #region Atributos
        private List<Departamento> _departamentos;
        private Departamento? _departamentoSeleccionado;

        private string? _nombre = string.Empty;
        private string? _apellidos = string.Empty;
        private string? _telefono = string.Empty;
        private string? _direccion = string.Empty;
        private string? _foto = string.Empty;
        private DateTime _fechaNacimiento = DateTime.Now;

        private DelegateCommand _btnGuardarCmd;
        private DelegateCommand _btnVolverCmd;
        #endregion

        #region Propiedades
        public List<Departamento> Departamentos { get => _departamentos; }
        public Departamento? DepartamentoSeleccionado
        {
            get => _departamentoSeleccionado;
            set
            {
                _departamentoSeleccionado = value;
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }
        public string? Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                NotifyPropertyChanged(nameof(Nombre));
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }
        public string? Apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                NotifyPropertyChanged(nameof(Apellidos));
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }
        public string? Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                NotifyPropertyChanged(nameof(Telefono));
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }
        public string? Direccion
        {
            get => _direccion;
            set
            {
                _direccion = value;
                NotifyPropertyChanged(nameof(Direccion));
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }
        public string? Foto
        {
            get => _foto;
            set
            {
                _foto = value;
                NotifyPropertyChanged(nameof(Foto));
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }
        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set
            {
                _fechaNacimiento = value;
                NotifyPropertyChanged(nameof(FechaNacimiento));
                _btnGuardarCmd.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand BtnGuardarCmd { get => _btnGuardarCmd; }
        public DelegateCommand BtnVolverCmd { get => _btnVolverCmd; }
        #endregion

        #region Constructores
        public CrearPersonaVM()
        {
            _departamentos = DepartamentoHandlerBL.getDepartamentos();
            _btnGuardarCmd = new DelegateCommand(_btnGuardarCmd_Execute, _btnGuardarCmd_CanExecute);
            _btnVolverCmd = new DelegateCommand(_btnVolverCmdExecute);
        }
        #endregion

        #region Delegates
        private bool _btnGuardarCmd_CanExecute()
        {
            if (string.IsNullOrWhiteSpace(_nombre)) return false;
            if (string.IsNullOrWhiteSpace(_apellidos)) return false;
            if (string.IsNullOrWhiteSpace(_telefono)) return false;
            if (string.IsNullOrWhiteSpace(_direccion)) return false;
            if (string.IsNullOrWhiteSpace(_foto)) return false;
            //if (_fechaNacimiento == null) return false;
            if (_departamentoSeleccionado == null) return false;

            return true;
        }

        private async void _btnGuardarCmd_Execute()
        {
            Persona p = new Persona(_nombre, _apellidos, _telefono, _direccion, _foto, _fechaNacimiento, _departamentoSeleccionado.ID); ;
            
            _nombre = string.Empty;
            _apellidos = string.Empty;
            _telefono = string.Empty;
            _direccion = string.Empty;
            _foto = string.Empty;
            _fechaNacimiento = DateTime.Now;
            _departamentoSeleccionado = null;

            PersonaHandlerBL.addPersona(p);
            await Shell.Current.GoToAsync("///listaPersonas");
        }

        private async void _btnVolverCmdExecute()
        {
            await Shell.Current.GoToAsync("///listaPersonas");
        }
        #endregion
    }
}
