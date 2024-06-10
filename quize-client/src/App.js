
import { BrowserRouter,Routes,Route } from 'react-router-dom';
import './App.css';
import Login from './components/Login';
import Quiz from './components/Quiz';
import Result from "./components/Result"
import Layout from './components/Layout';

function App() {
  return (
    <div className="App">
        <BrowserRouter>
          <Routes>
              <Route path = "/" element={<Login/>} />
              
              <Route path = "/" element={<Layout />} >
                   <Route path = "/quize" element={<Quiz/>} />
                   <Route path = "/result" element={<Result/>} />
              </Route>
              
          </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
