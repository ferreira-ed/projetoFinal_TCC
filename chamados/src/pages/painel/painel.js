import {Component} from  'react'
import api from '../../services/api'
import '../painel/equip.css'
import axios from 'axios'

import logoSenai from "../../assets/img/logoSenai.png"
import pessoa from "../../assets/img/pessoa.png"
import painel from "../../assets/img/painel.png"
import agenda from "../../assets/img/agenda.png"
import equipamentos from '../../assets/img/equipamentos.png'
import configuracao from "../../assets/img/configuracao.png"
import sair from "../../assets/img/sair.png"
import home from "../../assets/img/home.png"
import {Link} from 'react-router-dom'

export default class Painel extends Component{
    constructor(props){
        super(props)
        this.state = {
          listaChamados : []
        }
    }

    componentDidMount(){
      this.buscarEventos();
    }

    componentWillUnmount(){

    }

    //exclui um tipo de evento
    excluirTEid = (chamado) => {

        console.log("O tipo de evento " + chamado.idChamado + " foi selecionado")

        //chama a api e passa o id do tipo de evento que será excluido, pela url na requisição
        api.delete('/chamados/' + chamado.idChamado,
        {
            
            headers : {
                'Authorization' : `Bearer ${localStorage.getItem('token')}`
              }
        })

        .then(resposta => {
            if (resposta.status === 204){
                    console.log("Tipo de evento " + chamado.idChamado + " foi excluido!")
                }
            
        })

        .then(this.buscarEventos)

        .then(this.LimparCampos)

        .catch(erro => console.log(erro))
    }

    //faz a requisição e traz a lista de eventos
    buscarEventos = () => {
      //chama a api usando o axios
      axios('http://localhost:5000/api/chamados', {

            headers : {
                'Authorization' : `Bearer ${localStorage.getItem('token')}`
            }
        })

      .then(resposta => {
          //se a requisição retornar 200
          if(resposta.status === 200){
              this.setState({
                  //atualiza o state com os dados da api
                  listaChamados : resposta.data
              })
              console.log(resposta.data)
          }
      })

      .catch(erro => console.log(erro))
  }

    sair = () => {
        localStorage.removeItem("token")
        this.props.history.push("/")
    }

    render(){
        return (
            <main>
                <div class="sidebar">
        <div class="center">
           <menu>
           <div class="senai">
              <img src={logoSenai} alt="Senai"/>
                <p>SEJA BEM VINDO!</p>
            </div>
            <div class="efeito user">
                <img src={pessoa} alt="pessoa"/>
                <h3>Marcos Vinicius</h3>
                <p>Administrador do sistema</p>
            </div>
            <Link to = "/painel">
              <div class="efeito painel">
                  <img src={painel} alt="painel"/>
                  <p>Painel de controle</p>
              </div>
            </Link>
            <div class="efeito Agenda">
                <img src={agenda} alt="agenda"/>
                <p>Agenda</p>
            </div>
            <Link to ="/equipamentos">
              <div class="efeito Equipamentos">
                  <img src={equipamentos} alt="Equipamentos"/>
                  <p>Equipamentos</p>
              </div>
            </Link>
            <div class="efeito Configuracao">
                <img src={configuracao} alt="configuracao"/>
                <p>Configuração</p>
            </div>
            <div class="efeito Sair" onClick={this.sair}>
                <img src={sair} alt="sair"/>
                <p style={{color: "red"}}>Sair</p>
            </div>
          </menu>
        </div>
       </div>

       <section class="painel_content">
        <div class="top_painel">
            <form>
                <input type="text" placeholder="Digite o que procura"/>
                <i class="fas fa-search"></i>
            </form>
            <div class="data"></div>
        </div>
        <div class="painel_acao">
         <h2><img style={{height: "10px", width: "10px"}} src={home}/>Painel de Controle</h2>
         <div class="butao_acao">
           <button><i class="fab fa-facebook-messenger"></i>Incluir</button>
           <button><i class="fas fa-shopping-bag"></i>Imprimir</button>
         </div>
         <div class="filtro"><i class="fas fa-arrow-right"></i> Filtros<button>Nenhum</button></div>
        </div>

          
        <div class="container">
             <table class="tb">
                <thead>
                <tr>
                    <th>id</th>
                    <th>Usuario</th>
                    <th>Data</th>
                    <th>Tipo Problema</th>
                    <th>Tipo Serviço</th>
                    <th>Classe</th>
                    <th>Andar</th>
                    <th>Sala</th>
                    <th>Prioridade</th>
                    <th>Descrição</th>
                </tr>
                
                </thead> 
            
            <tbody>

            {
            this.state.listaChamados.map( evento => {
                return(
                    <tr key={evento.idChamado}>

                        <td>{evento.idChamado}</td>
                        <td>{evento.nomeUsuario}</td>
                        <td>{evento.data}</td>
                        <td>{evento.tipoProblema}</td>
                        <td>{evento.tipoServico}</td>
                        <td>{evento.classe}</td>
                        <td>{evento.andar}</td>
                        <td>{evento.sala}</td>
                        <td>{evento.prioridade}</td>
                        <td>{evento.descricao}</td>

                        {/* chama a função buscarTEid passando o evento selecionado */}
                        <td>
                        

                        {/* chama a função excluitTEid passando o evento selecionado */}
                    
                        
                        <button className='botao' onClick = {() => this.excluirTEid(evento)}>Excluir</button>
                    </td>
                    </tr>
                )
            })
        }
                </tbody>   
                </table>
                </div>
            </section>
            </main>
        )
    }
}