import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import './App.css';
import Home from './Components/Home';
import Music from "./Components/Music";
import Movies from "./Components/Movies";

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Home/>}></Route>
      <Route path="/music" element={<Music/>}></Route>
      <Route path="/movies" element={<Movies/>}></Route>
      

    </Routes>
  </BrowserRouter>
  );
}

export default App;
