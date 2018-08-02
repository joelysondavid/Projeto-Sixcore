var api = 'http://localhost:53731/api/paciente/';

var titulo = document.querySelector('#titulo-paciente');

var elementosPaciente = {
    nome: document.querySelector('#nome'),
    cpf: document.querySelector('#cpf'),
    historico: document.querySelector('#historico'),
    nascimento: document.querySelector('#nascimento')
};

var query = location.search.slice(1); // Pega as informações enviadas após o ponto de interrogação na URL

var partes = query.split('&'); // Caso tenha mais de um parâmetro eles serão separados pelo caracter & - A função split quebra a string em arrays, conforme um caracter informado

var data = {}; // Cria um objeto que conterá as informações passadas pela url

partes.forEach(function (parte) { // percorre as informações passadas

    var chaveValor = parte.split('='); // quebra em array o nome da informação e seu valor
    var chave = chaveValor[0]; // o nome da informação fica na posição 0
    var valor = chaveValor[1]; // o valor da informação fica na posição 1
    data[chave] = valor; // Essa é uma notação de array, porém, como chave não é um número, isso acaba também funcioando para criar um objeto
});

console.log(data); 

if(data.id) { // Se foi passado um id, quer dizer que eu estou alterando
    obterPaciente(data.id);
    titulo.innerHTML = 'Alterar Paciente';
}


document.querySelector('#form-paciente').addEventListener('submit', function (event) {

    event.preventDefault();

    var paciente = {
        nome: elementosPaciente.nome.value,
        cpf: elementosPaciente.cpf.value,
        historico: elementosPaciente.historico.value,
        nascimento: elementosPaciente.nascimento.value
    };

    if(data.id){
        alterarPaciente(data.id, paciente);
    }
    else{
        inserirPaciente(paciente);
    }

});

function inserirPaciente(paciente) {

    var request = new Request(api, {
        method: "POST",
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(paciente)
    });

    fetch(request)
        .then(function (response) {
            console.log(response);
            if (response.status == 201) {
                alert("Paciente inserido com sucesso");
                atribuirValorAoFormulario();
            } else {
		
		response.json().then(function(message){
			alert(message.error);
		});

            }
        })
        .catch(function (response) {
            console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });

}

function alterarPaciente(idPaciente, paciente) {

    var request = new Request(api + idPaciente, {
        method: "PUT",
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(paciente)
    });

    fetch(request)
        .then(function (response) {
            // console.log(response);
            if (response.status == 202) {
                alert("Paciente alterado com sucesso");
                window.location.href="paciente.html";
            } else {
		response.json().then(function(message){
			alert(message.error);
		});
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });

}

function obterPaciente(idPaciente) {
    var request = new Request(api + idPaciente, {
        method: "GET",
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    });

    fetch(request)
        .then(function (response) {
            // console.log(response);
            if (response.status == 200) {
                response.json()
                .then(function(paciente){
                    atribuirValorAoFormulario(paciente);
                });
            } else {
                alert("Ocorreu um erro ao obter o Paciente");
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });
}
function atribuirValorAoFormulario(paciente = {}) {
    elementosPaciente.nome.value = paciente.nome || '';
    elementosPaciente.cpf.value = paciente.cpf || '';
    elementosPaciente.historico.value = paciente.historico || '';
    elementosPaciente.nascimento.value = paciente.nascimento || '';
}