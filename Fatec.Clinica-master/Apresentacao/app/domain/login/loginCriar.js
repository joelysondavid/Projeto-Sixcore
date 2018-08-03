var api = 'http://localhost:53731/api/login/';


var titulo = document.querySelector('#titulo-login');


var elementosMedico = {
    nome: document.querySelector('#nome'),
    email: document.querySelector('#email'),
    senha: document.querySelector('#senha'),
    tipoAcesso: document.querySelector('#tipoAcesso')
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
    obterMedico(data.id);
    titulo.innerHTML = 'Alterar Login';
}
else{
    obterEspecialidades();
    titulo.innerHTML = 'Adicionar Login';
}

document.querySelector('#form-login').addEventListener('submit', function (event) {

    event.preventDefault();

    var login = {
        nome: elementosLogin.nome.value,
        emial: elementosLogin.email.value,
        senha: elementosLogin.senha.value,
        tipoAcesso:elementosLogin.tipoAcesso.value
    };

    if(data.id){
        alterarlogin(data.id, login);
    }
    else{
        inserirLogin(login);
    }

});

function inserirMedico(login) {

    var request = new Request(api, {
        method: "POST",
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(login)
    });

    fetch(request)
        .then(function (response) {
            console.log(response);
            if (response.status == 201) {
                alert("Login inserido com sucesso");
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

function alterarlogin(idLogin, login) {

    var request = new Request(api + idLogin, {
        method: "PUT",
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(login)
    });

    fetch(request)
        .then(function (response) {
            // console.log(response);
            if (response.status == 202) {
                alert("Login alterado com sucesso");
               // window.location.href="login.html";
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

function obterLogin(idLogin) {
    var request = new Request(api + idLogin, {
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
                .then(function(login){
                    atribuirValorAoFormulario(medico);
                    obterEspecialidades(medico.idEspecialidade);
                });
            } else {
                alert("Ocorreu um erro ao obter o médico");
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });
}

function obterEspecialidades(id){
    var request = new Request(apiEspecialidade, {
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
                .then(function(especialidades){
                    updateTemplateEspecialidades(especialidades, id);
                });
            } else {
                alert("Ocorreu um erro ao obter as especialidades");
            }
        })
        .catch(function (response) {
            // console.log(response);
            alert("Desculpe, ocorreu um erro no servidor.");
        });
}

function updateTemplateEspecialidades(especialidades, id){
    especialidade.innerHTML = templateEspecialidades(especialidades, id);
}

function templateEspecialidades(especialidades = [], id = null){
    return `
        <option>Selecione</option>
        ${
            especialidades.map(function(especialidade){
                return `
                    <option value="${especialidade.id}" ${especialidade.id == id ? 'selected' : ''}>${especialidade.nome}</option>
                `;
            }).join('')
        }
    `;
}

function atribuirValorAoFormulario(medico = {}) {
    elementosMedico.nome.value = medico.nome || '';
    elementosMedico.cpf.value = medico.cpf || '';
    elementosMedico.crm.value = medico.crm || '';
    elementosMedico.especialidade.value = medico.idEspecialidade || '';
}