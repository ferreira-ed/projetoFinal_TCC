import {Component} from  'react'
import api from '../../services/api'
import '../painel/equip.css'

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

        }
    }

    componentDidMount(){

    }

    componentWillUnmount(){

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

          <div class="tabela">
          <div class="t_geral">
            <div class="borda icone"></div>
            <div class="borda icone"><i class="fas fa-pencil-alt"></i><i class="fas fa-trash-alt"></i></div>
            <div class="borda icone"><i class="fas fa-pencil-alt"></i><i class="fas fa-trash-alt"></i></div>
            <div class="borda icone"><i class="fas fa-pencil-alt"></i><i class="fas fa-trash-alt"></i></div>
            <div class="borda icone"><i class="fas fa-pencil-alt"></i><i class="fas fa-trash-alt"></i></div>
        </div>
          
          <div class="t_geral">
            <div class="borda nome">
                <p><b>Nome</b></p>
            </div>
            <div class="borda nome">
                <p>Gabriel Alves</p>
            </div>
            <div class="borda nome">
                <p>Elias Alves</p>
            </div>
            <div class="borda nome">
                <p>José Alteiro</p>
            </div>
            <div class="borda nome">
                <p>Felipe dias Santos</p>
            </div>

          </div>
         
          <div class="t_geral">
            <div class="borda tempo">
                <p><b>Data</b></p>
              </div>
              <div class="borda tempo">
                <p>9/11/2021 - 14:54</p>
              </div>
              <div class="borda tempo">
                <p>12/11/2021 - 14:54</p>
              </div>
              <div class="borda tempo">
                <p>18/11/2021 - 13:54</p>
              </div>
              <div class="borda tempo">
                <p>1/10/2021 - 01:54</p>
              </div>
          </div>
          
          <div class="t_geral">
            <div class="borda Tipo_servico">
                <p><b>Tipo de serviço</b></p>
              </div>
              <div class="borda Tipo_servico">
                <p>Manutenção</p>
              </div>
              <div class="borda Tipo_servico">
                <p>Limpeza</p>
              </div>
              <div class="borda Tipo_servico">
                <p>Suporte</p>
              </div>
              <div class="borda Tipo_servico">
                <p>Manutenção</p>
              </div>
          </div>
          <div class="t_geral">
            <div class="borda situacao">
                <p><b>Situação</b></p>
              </div>
              <div class="borda situacao">
                <p>Em atendimento</p>
              </div>
              <div class="borda situacao">
                <p>Pausado</p>
              </div>
              
              <div class="borda situacao">
                <p>Pausado</p>
              </div>
              <div class="borda situacao">
                <p>Pausado</p>
              </div>
            </div>
          
          <div class="t_geral">
            <div class="borda Prioridade">
                <p><b>Prioridade</b></p>
            </div>
            <div class="borda Prioridade">
                <p>Alta Prioridade</p>
            </div>
            <div class="borda Prioridade">
                <p>Baixa Prioridade</p>
            </div>
            <div class="borda Prioridade">
                <p>Critico</p>
            </div>
            <div class="borda Prioridade">
                <p>Média Prioridade</p>
            </div>
          </div>
       
          <div class="t_geral">
            <div class="borda Observacaes">
                <p><b>Observações</b></p>
            </div>
            <div class="borda Observacaes">
                
            </div>
            <div class="borda Observacaes">
                
            </div>
            <div class="borda Observacaes">
                
            </div>
            <div class="borda Observacaes">
                
            </div>
          </div>
       
          </div>
          
       </section>
            </main>
        )
    }
}