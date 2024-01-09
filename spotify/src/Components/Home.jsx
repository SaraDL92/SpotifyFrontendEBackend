import {  Link } from 'react-router-dom';

function Home()

{return(
    <div>
    <h1>Choose your service:</h1>
    <Link to={"/music"}><h2>MUSIC</h2></Link>
   <Link to={"/movies"}><h2> MOVIE</h2></Link>
    </div>
)



}
export default Home;