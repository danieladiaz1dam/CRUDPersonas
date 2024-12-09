using ASP.Models;
using BL;
using ENT;
using MAUI.ViewModel.Utilities;
using System.Collections.ObjectModel;

namespace MAUI.ViewModel
{
    public class ListadoPersonasConDepartamentoVM : VMBase
    {
        #region Atributos
        private ObservableCollection<PersonaConDepartamento> _lista;
        private PersonaConDepartamento? _personaSeleccionada;

        private DelegateCommand _btnDetallesCmd;
        private DelegateCommand _btnEditarCmd;
        private DelegateCommand _btnBorrarCmd;
        private DelegateCommand _btnRecargarCmd;
        private DelegateCommand _btnCrearCmd;
        #endregion

        #region Propiedades
        public ObservableCollection<PersonaConDepartamento> Lista { get { return _lista; } }
        public PersonaConDepartamento? PersonaSeleccionada
        {
            get => _personaSeleccionada;

            set
            {
                _personaSeleccionada = value;

                NotifyPropertyChanged(nameof(PersonaSeleccionada));

                _btnDetallesCmd.RaiseCanExecuteChanged();
                _btnEditarCmd.RaiseCanExecuteChanged();
                _btnBorrarCmd.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand BtnDetallesCmd { get => _btnDetallesCmd; }
        public DelegateCommand BtnEditarCmd { get => _btnEditarCmd; }
        public DelegateCommand BtnBorrarCmd { get => _btnBorrarCmd; }
        public DelegateCommand BtnRecargarCmd { get => _btnRecargarCmd; }
        public DelegateCommand BtnCrearCmd { get => _btnCrearCmd; }
        #endregion

        #region Constructores
        public ListadoPersonasConDepartamentoVM()
        {
            initLista();

            _btnDetallesCmd = new DelegateCommand(_btnDetallesCmd_Execute, _btnsCmd_CanExecute);
            _btnEditarCmd = new DelegateCommand(_btnEditarCmd_Execute, _btnsCmd_CanExecute);
            _btnBorrarCmd = new DelegateCommand(_btnBorrarCmd_Execute, _btnsCmd_CanExecute);
            _btnRecargarCmd = new DelegateCommand(_btnRecargarCmd_Execute);
            _btnCrearCmd = new DelegateCommand(_btnCrearCmd_Execute);
        }
        #endregion

        private void initLista()
        {
            _lista = new ObservableCollection<PersonaConDepartamento>();

            List<Persona> personas;
            List<Departamento> departamentos;

            personas = PersonaHandlerBL.getPersonas();
            departamentos = DepartamentoHandlerBL.getDepartamentos();

            foreach (Persona persona in personas)
                _lista.Add(new PersonaConDepartamento(persona, departamentos));
        }

        /// <summary>
        /// Funcion que comprueba si se ha seleccionado a una persona y activa los botones
        /// </summary>
        /// <returns></returns>
        private bool _btnsCmd_CanExecute()
        {
            return _personaSeleccionada != null;
        }

        #region Funciones

        private async void _btnDetallesCmd_Execute()
        {
            // Actualizar datos de la DB
            PersonaConDepartamento p = PersonaHandlerBL.getPersonaConDepartamento(_personaSeleccionada.Id);

            // Si la persona aun existe
            if (p.Id != -1)
            {
                var queryParams = new Dictionary<string, object>()
                {
                    {"Persona", p }
                };

                await Shell.Current.GoToAsync("///detallesPersona", queryParams);
            }
        }

        private async void _btnEditarCmd_Execute()
        {
            PersonaConDepartamento p = PersonaHandlerBL.getPersonaConDepartamento(_personaSeleccionada.Id);
            Departamento d = DepartamentoHandlerBL.GetDepartamento(_personaSeleccionada.IDDepartamento ?? 0);

            if (p.Id != -1)
            {
                var queryParams = new Dictionary<string, object>()
                {
                    {"Persona", p},
                    {"Departamento", d}
                };

                await Shell.Current.GoToAsync("///editarPersona", queryParams);
            }
        }

        private void _btnBorrarCmd_Execute()
        {
            PersonaHandlerBL.deletePersona(_personaSeleccionada.Id);
            _lista.Remove(_personaSeleccionada);
            _personaSeleccionada = null;
            NotifyPropertyChanged(nameof(PersonaSeleccionada));
            NotifyPropertyChanged(nameof(Lista));
        }

        private void _btnRecargarCmd_Execute()
        {
            initLista();
            NotifyPropertyChanged(nameof(Lista));
        }

        private async void _btnCrearCmd_Execute()
        {
            await Shell.Current.GoToAsync("///crearPersona");
        }
        #endregion
    }
}
