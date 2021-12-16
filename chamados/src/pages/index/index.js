import {Component} from 'react'
import api from '../../services/api'
import '../index/style.css'

import logoSenai from "../../assets/img/logoSenai.png"
import profile from "../../assets/img/Profile.png"
import monitor from "../../assets/img/Monitor.png"
import engrenagem1 from "../../assets/img/Engrenagem 1.png"
import logout from "../../assets/img/logout.png"

export default class Index extends Component{
    constructor(props){
        super(props)
        this.state = {
            idUsuario : '',
            nomeUsuario : '',
            data : new Date(),
            tipoProblema : '',
            tipoServico : '',
            classe : '',
            andar : '',
            sala : '',
            descricao : '',
            prioridade: ''
        }
    }

    componentDidMount(){

    }

    componentWillUnmount(){

    }

    atualizarCampo = async (campo) => {
        await this.setState({[campo.target.name] : campo.target.value})
    }

    CadastrarChamada = () => {
        api.post('/chamados', {
            nomeUsuario : this.state.nomeUsuario,
            data : new Date(this.state.data),
            tipoProblema : this.state.tipoProblema,
            tipoServico : this.state.tipoServico,
            classe : this.state.classe,
            andar : this.state.andar,
            sala : this.state.sala,
            descricao : this.state.descricao,
            prioridade : this.state.prioridade
        }, {
            headers : {
                "Authorization" : "Bearer " + localStorage.getItem("token")
            }
        }).then(response => {
            if(response.status == 201)
            {
                console.log("Chamada cadastrada")
            }
        }).catch(ex => {
            console.log(ex)
        })
    }

    sair = () => {
        localStorage.removeItem("token")

        this.props.history.push("/")
    }

    render(){
        return(
            <main>
                <div class="content">

{/* MENU DE NAVEGAÇÃO */}
<nav class="cabecalho__menuNavegacao">

    {/* IMAGEM LOGO */}
    <figure class="cabecalho__logo">
        <img src={logoSenai} alt="logo Senai" /> 
        <figcaption>Seja bem vindo!</figcaption> 
    </figure>

    {/* LISTA DE LINKS */}
    <ul class="cabecalho__menuLista">

        <li class="cabecalho__menuItem"> 
            <a href="#">
                <img src={profile} alt="Foto perfil" />
            </a>
            <span>Professor</span>
        </li>

        <li class="cabecalho__menuOption"> 
            <a href="#">
            <img src={monitor} alt="Chamado" />
            <figcaption>Criar Chamado</figcaption>
            </a>
        </li>

        <li class="cabecalho__menuOption"> 
            <a href="#">
            <img src={engrenagem1} alt="Configuração" />
            <figcaption>Configuração</figcaption>
            </a>
        </li>

        <li class="cabecalho__menuOption" onClick={this.sair}> 
            <a href="#">
            <img src={logout} alt="logout" />
            <figcaption class="btn-sair">Sair</figcaption>
            </a>
        </li>
    </ul>

</nav>

<section class="chamados">
  <div class="part1">
    <div class="content_chamado">
    <h2>Internet não está funcionando</h2>
     <p>alta prioridade</p>
     <div class="anexo">
       <div class="wrapper"><i class="fas fa-paperclip"></i><p>Anexos</p></div>
     </div>
       <form onSubmit={this.CadastrarChamada}>
      <p style={{fontWeight: 'bold'}}>Quem está solicitando o chamado?</p>
       <input 
        className="input-teste"
       type="text" 
       placeholder="Saulo Santos" 
       name='nomeUsuario'
       value={this.state.nomeUsuario}
       onChange={this.atualizarCampo}
       style={{marginTop:15}}
       required
       />
       <div class="data"><span>Data</span> <input type="date" value={this.state.data} name="data" onChange={this.atualizarCampo} required/></div>
       <div class="tipo_problema">Tipo de problema
           <input
           className="input-teste"
           type='text'
           name="tipoProblema"
           value={this.state.tipoProblema}
           onChange={this.atualizarCampo}
        //    style={{marginLeft: '0.5em', backgroundColor: '#B7B7B7', borderRadius: 4, width: '13em'}}
           placeholder='Ex: Redes'
           required
           />
       </div>
       <div class="tipo_servico">Tipo de serviço
       <input
            className="input-teste"
           type='text'
           name="tipoServico"
           value={this.state.tipoServico}
           onChange={this.atualizarCampo}
           style={{marginLeft: '2em'}}
           placeholder='Ex: Manutenção'
           required
           />
     </div>
    <div class="classe" value={this.state.tipoProblema} name="tipoProblema" onChange={this.atualizarCampo}> Classe
        <input
            className="input-teste"
           type='text'
           name="classe"
           value={this.state.classe}
           onChange={this.atualizarCampo}
           style={{marginLeft: '6.5em'}}
           placeholder='Ex: Falta de internet'
           required
           />

    </div>
 <div class="Andar">Andar
        <input
            className="input-teste"
           type='text'
           name="andar"
           value={this.state.andar}
           onChange={this.atualizarCampo}
           style={{marginLeft: '7em'}}
           placeholder='n°2'
           required
           />
</div>    
 <div class="Sala">Sala
        <input
        className="input-teste"
           type='text'
           name="sala"
           value={this.state.sala}
           onChange={this.atualizarCampo}
           style={{marginLeft: '8em'}}
           placeholder='Sala 3'
           required
           />
 </div>
 
 <div class="Sala">Prioridade
        <input
        className="input-teste"
           type='text'
           name="prioridade"
           value={this.state.prioridade}
           onChange={this.atualizarCampo}
           style={{marginLeft: '5em'}}
           placeholder='Alta, Baixa'
           required
           />
 </div>
 <div class="Detalhes" style={{marginTop:30}}>Detalhes da solicitação
        <input
        className="input-teste"
        type='text'
           name="descricao"
           value={this.state.descricao}
           onChange={this.atualizarCampo}
           style={{marginLeft: '1em', marginTop: '2em', display: 'flex', marginTop: 20, width:'20em', height: '10em', marginRight:'2em', textAlign:''}}
           placeholder='Digite Aqui...'
           required
           />
        </div>
<div class="acao"><button type='submit' style={{marginBottom: '20em'}}>Enviar</button></div>
</form>

    </div>
  </div>
  <div class="part2">
    <div class="content_chamado2">
      <h3>Solução de problema</h3>
      <p>Descreva como o seu problema foi resolvido</p>
      <textarea placeholder="Digite aqui..."></textarea>
    </div>
    </div>
</section>

</div>
        </main>
        )
    }
}