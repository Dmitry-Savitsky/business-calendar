import logo from './logo.svg';
import './App.css';
import { Component } from 'react';

class App extends Component {
  constructor() {
    super();
    this.state = {
      executors: []
    };

    // Привязываем метод GetExecutors к контексту класса
    this.GetExecutors = this.GetExecutors.bind(this);
  }

  // Объявляем GetExecutors как метод класса
  GetExecutors = async () => {
    var response = await fetch('api/executors', {
      method: 'get'
    });

    var responsejson = await response.json();
    this.setState({
      executors: responsejson
    });
  };

  render() {
    const executors = this.state.executors.map((item, index) => (
      <li key={index}>{item.name}</li>
    ));
    return (
      <div className='App'>
        <button onClick={this.GetExecutors}>Загрузить список пользователей</button>
        <ul>{executors}</ul>
      </div>
    );
  }
}

export default App;