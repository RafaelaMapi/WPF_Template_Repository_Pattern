using Caliburn.Micro;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using Core.Interfaces.Services.Domain;

namespace MainDesktopUI.ViewModels
{
    
    class MainViewModel : Conductor<object>.Collection.OneActive
    {
        /// <summary>
        /// The Serilog ILogger variable.
        /// </summary>
        private readonly Serilog.ILogger _logger;

        /// <summary>
        /// The _event aggregator.
        /// </summary>   
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// The _client service.
        /// </summary>
        private readonly IClientService _clientService;

        /// <summary>
        /// The _container.
        /// </summary>    
        private readonly SimpleContainer _container;

        public MainViewModel(IEventAggregator eventagg, SimpleContainer containerIn, ILogger logger, IClientService clientService)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", true);
            this._eventAggregator = eventagg;
            this._container = containerIn;
            this._eventAggregator.SubscribeOnPublishedThread(this);
            //Add start PAge here
            //this.ActivateItemAsync(this._container.GetInstance<HomeViewModel>());

            _logger = logger;
            _logger.Information("****#### SISTEMA FOI INICIADO ####****");


            // inicializa a variavel com o servico
            _clientService = clientService;

            // cria a table no banco de dados se ainda não existe
            _clientService.CreateTable();


        }

    }
}
