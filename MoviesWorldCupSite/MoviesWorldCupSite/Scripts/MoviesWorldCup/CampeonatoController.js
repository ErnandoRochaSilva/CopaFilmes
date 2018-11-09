$(document).ready(function () {

    var maximoCompetidores = 8;
    var qtdeCompetidores = 0;

    $('#ProcessarCampeonato').on('click', ProcessarCampeonato);

    function ProcessarCampeonato() {

        if (ValidarSelecaoCompetidores() === false) {
            alert("Favor selecionar 8 competidores para iniciar o campeonato.");
            return;
        }

        debugger;

        var moviesSelected = JSON.stringify($("#formSelectCompetidores").serializeArray());

        $.ajax({
            url: 'Campeonato/ProcessarCampeonato',
            type: "POST",
            data: { moviesSelected },
            success: function (retorno) {
                $('#conteudo_ajax').html(retorno);
            },
            error: function (retorno) {

            }
        });
    }

    $("input[type='checkbox']").on('click',
        function (e) {
            var checkbox = $(this);

            if (LimitarSelecaoCompetidores()) {
                if (checkbox.is(":checked")) {
                    alert("Foram selecionados o total de competidores permitido para o campeonato!");
                    e.preventDefault();
                    return false;
                }
            } else {

                if (checkbox.is(":checked")) {
                    qtdeCompetidores++
                    exibeQuantidadeFilmesSelecioandos();
                } else {
                    qtdeCompetidores--
                    exibeQuantidadeFilmesSelecioandos();
                }
            }  
        }
    );

    //Exibir quantidade de filmes selecionados para usuario
    function exibeQuantidadeFilmesSelecioandos() {
        if ($("#TotalFilmes").text() === qtdeCompetidores) {
            qtdeCompetidores = $("#TotalFilmes").text();
        }
        
        $("#TotalFilmes").html(qtdeCompetidores);
    }

    //Funcao para limitar quantidade maxima de competidores do campeonato
    function LimitarSelecaoCompetidores() {
        var qtdeCompetidores = verificarCompetidoresSelecionados();

        return (qtdeCompetidores > maximoCompetidores);
    }

    //Funcao para validar se máximo de competidores foi selecionado ou não
    function ValidarSelecaoCompetidores() {
        var retono = false;
        var qtdeCompetidores = verificarCompetidoresSelecionados();

        if (qtdeCompetidores > 0 || qtdeCompetidores > maximoCompetidores) {
            retono = true;
        }

        return retono;
    }

    //Funcao para verificar competidores selecionados
    function verificarCompetidoresSelecionados() {
        var checkBoxes = document.querySelectorAll("input[type='checkbox']");
        var qtdeCompetidores = 0;

        for (var i = 0; i < checkBoxes.length; i++) {
            if (checkBoxes[i].checked) {
                qtdeCompetidores = qtdeCompetidores + 1;
            }
        }

        return qtdeCompetidores;
    }
});