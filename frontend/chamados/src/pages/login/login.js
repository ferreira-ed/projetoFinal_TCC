import {parseJwt} from '../../services/auth';
import React, {Component} from 'react';
import api from '../../services/api';

import logo from '../../assets/img/logo senai.png'
import img from '../../assets/img/engenharia-de-producao.png'

class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha: ''
        }
    }

    login = async (event) => {

        event.preventDefault();

        //define a url e os parâmetros da requisição
         api.post('/login', {
            email : this.state.email,
            senha : this.state.senha
            
        })

        
        .then(resposta => {
            
            if(resposta.status === 200){
                localStorage.setItem('token', resposta.data.token)

                this.props.history.push('/')

                if (parseJwt().role === '2') {
                    this.props.history.push('/consultasm')
                }

                if(parseJwt().role === '4'){
                    this.props.history.push('/')
                }
                
            }
            console.log(this.state.email + ' ' +  this.state.senha)

    
        })

        .catch(erro => console.log(erro))
    }

    //atualizao state de acordo com o input
    atualizaState = async (campo) =>{
        await this.setState({ [campo.target.name] : campo.target.value})

    }

    render(){
        return(
            <div>
                <main >
                    <img src={img} style={{width: 800, height: 1098, display: 'flex', position: 'absolute', left: 0, top: 0, bottom: 0}}/>
                    <section style={{display:'flex', justifyContent: 'end', alignItems: 'center', width: '100w', height: '100vh', marginRight: '20em', marginBottom: '7em'}}>
                        <form onSubmit={this.login} style={{display: 'flex', margin: 0, alignItems: 'center', flexDirection: 'column'}}>
                            <img src={logo} style={{width: 300, height: 89, marginBottom: '2em'}}/>
                            <h2 style={{textAlign:'center', fontSize: 20, fontWeight: 'bold', textTransform: 'uppercase', marginBottom: '3em'}}>Faça seu login para acessar a plataforma</h2>
                            <p style={{display: 'flex', marginRight: '19.5em', textTransform: 'uppercase'}}>Email</p>
                            <input
                                type='text' 
                                name='email'
                                value={this.state.email}
                                onChange={this.atualizaState}
                                placeholder = 'email@email.com'
                                style={{marginBottom: 30, border: 0, borderBottomWidth: 1, borderBottomColor:'#FE0000', width: 350, height: 30, borderStyle: 'solid', fontWeight: 'bold', marginBottom: '4em', fontSize: '15px'}}
                            />

                            <p style={{display: 'flex', marginRight: '19em', textTransform: 'uppercase'}}>Senha</p>
                            <input
                                type='password' 
                                name='senha'
                                value={this.state.senha}
                                onChange={this.atualizaState}
                                placeholder = '* * * * * * * * *'
                                style={{marginBottom: 30, border: 0,  width: 350, height: 30, borderBottomWidth: 1, borderBottomColor: '#FE0000', borderStyle: 'solid', fontWeight: 'bold',  textTransform: 'uppercase'}}
                            />
                            <button type="submit" style={{border: 0, width: 140, height: 35, backgroundColor: '#FE0000', borderRadius: 4, color: 'white', fontWeight:'bold', textTransform: 'uppercase', marginTop: '2.5em'}}>Acessar</button>
                            
                            <p style={{marginTop: '3em'}}>Não tem acesso? <a style= {{fontWeight: 'bold', color: "#005FFF", textDecoration: 'none', display: 'inline'}} href = "cadastro">Registre-se Aqui</a></p> 
                        </form>
                    </section>
                </main>
            </div>

        )
    }
}

export default Login;