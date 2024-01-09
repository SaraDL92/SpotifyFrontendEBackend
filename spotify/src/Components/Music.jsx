import { useEffect } from 'react';
import { useState } from 'react';
import axios from 'axios';

function Music() {
    const [musicData, setMusicData] = useState(null);
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          const response = await axios.get('localhost:44347/api/Song'); // Sostituisci 'URL_DEL_API' con il tuo URL API
          setMusicData(response.data);
        } catch (error) {
          console.error('Errore nella richiesta GET:', error);
        }
      };
  
      fetchData();
    }, []); // L'array vuoto indica che il useEffect verrà eseguito solo al montaggio del componente
  
    return (
      <div>
        <h2>Music Page</h2>
        {musicData && (
          <ul>
            {musicData.map((item) => (
              <li key={item.id_Song}>{item.titleOfSong}</li>
            ))}
          </ul>
        )}
      </div>
    );
  }
  
export default Music;