$(document).ready(function () {

    var maximoCompetidores = 8;
    var qtdeCompetidores = 0;

    var moviesDTO = {};
        moviesDTO.Id = [];

    $('#ProcessarCampeonato').on('click', ProcessarCampeonato);

    function ProcessarCampeonato() {

        if (ValidarSelecaoCompetidores() === true) {
            alert("Favor selecionar 8 competidores para iniciar o campeonato.");
            return;
        }

        moviesDTO = montarArrayMoviesSelecionados();

        var moviesSelected = JSON.stringify(moviesDTO);

        //var moviesSelected = JSON.stringify(moviesDTO);

        $.ajax({
            url: 'Campeonato/ProcessarCampeonato',
            type: "POST",
            data: { 'moviesIds': moviesSelected },
            success: function (retorno) {
                exibeModalComCampeos(retorno);
               
            }
            //,
            //failure: function (retorno) {
            //    alert(retorno.responseText);
            //},
            //error: function (retorno) {
            //    alert(retorno.responseText);
            //}
        });
    }

    function exibeModalComCampeos(retorno) {

        var primeiroColocadoTit = retorno[0].Titulo;
        var primeiroColocadoAno = retorno[0].Ano;
        var primeiroColocadoNota = retorno[0].Nota;

        var segundoColocadoTit = retorno[1].Titulo;
        var segundoColocadoAno = retorno[1].Ano;
        var segundoColocadoNota = retorno[1].Nota;

        $("#primeiroColocado").append('<strong>Primeiro colocado: </strong>' + primeiroColocadoTit + ' <strong>Ano: </strong>' + primeiroColocadoAno + ' <strong>Nota:<strong> ' + primeiroColocadoNota);
        $("#segundoColocado").append('<strong>Segundo colocado: </strong>' + segundoColocadoTit + ' <strong>Ano: </strong>' + segundoColocadoAno + ' <strong>Nota:<strong> ' + segundoColocadoNota);

        //$('#primeiroColocado .test').text('Welcome');

        $("#modal-mensagem").modal();
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

    //Montar DTO de filmes selecionados
    function montarArrayMoviesSelecionados() {
        var checkBoxes = document.querySelectorAll("input[type='checkbox']");

        for (var i = 0; i < checkBoxes.length; i++) {            
            if (checkBoxes[i].checked) {
                var Id = checkBoxes[i].id;
                moviesDTO.Id.push(Id);
            }
        }
        return moviesDTO;
    }

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

        if (qtdeCompetidores === 0 || qtdeCompetidores < maximoCompetidores) {
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