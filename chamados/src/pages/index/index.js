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
            nomeUsuario : '',
            data : new Date(),
            tipoProblema : '',
            tipoServico : '',
            classe : '',
            andar : '',
            sala : '',
            descricao : ''
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
            descricao : this.state.descricao
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
      <p>Quem está solicitando o chamado?</p>
       <input 
       type="text" 
       placeholder="Saulo Santos" 
       name='nomeUsuario'
       value={this.state.nomeUsuario}
       
       />
       <div class="data"><span>Data</span> <input type="date" value={this.state.data} name="data" onChange={this.atualizarCampo} required/></div>
       <div class="tipo_problema"><span>Tipo de problema <as>*</as></span><select>
           <option value="redes" selected>redes</option>
       </select></div>
       <div class="tipo_servico"><span>Tipo de serviço <as>*</as></span><select>
        <option value="redes" selected>manutenção</option>
    </select></div>
    <div class="classe" value={this.state.tipoProblema} name="tipoProblema" onChange={this.atualizarCampo}><span>classe </span><select>
        <option value="redes" selected>Selecione</option>
        <option value="Cabeamento de redes" >Cabeamento de redes</option>
        <option value="Login de rede" >Login de rede</option>
        <option value="Equipamentos danificados" >Equipamentos danificados</option>
        <option value="Falta de internet" >Falta de internet</option>
        <option value="Problema de comunicação com a impressora" >Problema de comunicação com a impressora</option>
        <option value="Problema de compartilhameno de dados" >Problema de compartilhameno de dados</option>
        <option value="outros..." >outros...</option>
    </select></div>
 <div class="Andar"><span>Andar <as>*</as></span><select><option value="2°"selected>2°</option></select></div>    
 <div class="Sala"><span>Sala <as>*</as></span><select><option value="sala 13"selected>sala 13</option></select></div>
 <div class="Detalhes"><span>Detalhes da Solicitação</span><textarea placeholder="Digite.."></textarea></div>
<div class="acao"><button>Enviar</button></div>
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