$(document).ready(function () {
    // 1. Cargar datos Mock de la Compañía (Información Superior)
    loadCompanyData();

    // 2. Cargar jqGrid con Datos Mock de las Plantas
    initPlantsGrid();

    $('#btnPrint').on('click', function (event) {
        event.preventDefault();
        const url = $('#UrlPrint').val();
        if (url) {
            window.location.assign(url);
        }
    })
});

function loadCompanyData() {
    // Datos simulados de la compañía
    const companyMock = {
        name: "Global Tech Industries S.A.",
        code: "GTI-2026",
        rfc: "GTI900101ABC",
        taxAddress: "Av. de la Industria #1500, Monterrey, NL",
        status: "Activo"
    };

    // Asignar los datos a la tarjeta superior
    $("#companyName").text(companyMock.name);
    $("#companyCode").text(companyMock.code);
    $("#companyRfc").text(companyMock.rfc);
    $("#companyAddress").text(companyMock.taxAddress);
    $("#companyStatus").text(companyMock.status);
}

function initPlantsGrid() {
    // Datos simulados para las plantas de la compañía
    const plantsMockData = [
        { id: 101, code: "PLT-MX-01", name: "Planta Monterrey", location: "Monterrey, NL", employees: 450, status: "Operativa" },
        { id: 102, code: "PLT-MX-02", name: "Planta Saltillo", location: "Saltillo, Coah.", employees: 320, status: "Operativa" },
        { id: 103, code: "PLT-MX-03", name: "Planta Querétaro", location: "El Marqués, Qro.", employees: 600, status: "Operativa" },
        { id: 104, code: "PLT-US-01", name: "Planta McAllen", location: "McAllen, TX", employees: 180, status: "En Mantenimiento" },
        { id: 105, code: "PLT-MX-04", name: "Planta Tijuana", location: "Tijuana, B.C.", employees: 510, status: "Operativa" },
        { id: 106, code: "PLT-MX-05", name: "Planta Guadalajara", location: "El Salto, Jal.", employees: 290, status: "Inactiva" }
    ];

    // Inicialización del jqGrid
    $("#plantsGrid").jqGrid({
        datatype: "local",
        data: plantsMockData,
        colNames: ['ID', 'Código', 'Nombre de la Planta', 'Ubicación / Ciudad', 'Empleados', 'Estatus'],
        colModel: [
            { name: 'id', index: 'id', width: 60, align: 'center', key: true, numeric: true },
            { name: 'code', index: 'code', width: 110, align: 'center' },
            { name: 'name', index: 'name', width: 200 },
            { name: 'location', index: 'location', width: 200 },
            { name: 'employees', index: 'employees', width: 100, align: 'right', formatter: 'integer' },
            {
                name: 'status',
                index: 'status',
                width: 140,
                align: 'center',
                formatter: function (cellvalue) {
                    if (cellvalue === "Operativa") {
                        return '<span class="badge bg-success">Operativa</span>';
                    } else if (cellvalue === "En Mantenimiento") {
                        return '<span class="badge bg-warning text-dark">Mantenimiento</span>';
                    } else {
                        return '<span class="badge bg-danger">Inactiva</span>';
                    }
                }
            }
        ],
        pager: "#plantsPager",
        rowNum: 5,
        rowList: [5, 10, 20],
        sortname: 'id',
        sortorder: 'asc',
        viewrecords: true,
        autowidth: true,
        shrinkToFit: true,
        height: 'auto',
        caption: "Plantas de la Compañía"
    });

    // Ajustar responsividad al redimensionar la ventana
    $(window).on('resize', function () {
        const width = $('#plantsGrid').closest('.card-body').width();
        if (width) {
            $("#plantsGrid").jqGrid('setGridWidth', width);
        }
    });

    // Ajustar ancho inicial una vez renderizado el DOM
    setTimeout(function () {
        const width = $('#plantsGrid').closest('.card-body').width();
        if (width) {
            $("#plantsGrid").jqGrid('setGridWidth', width);
        }
    }, 100);
}