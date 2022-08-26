import Header from '../components/Header'
import TopTable from '../components/TopTable';
import axios from "axios";
import { useEffect, useState } from 'react';
import "./css/TopPage.css";

function TopPage(){
    const [games, setGames] = useState([])

    useEffect(() => {
        getTop()
    }, []);

    const getTop = async () => {
        await axios
          .get(`${process.env.REACT_APP_SERVERIP}/Games/top`)
          .then((res) => setGames(res.data));
      };

    return(
        <div className='content'>
            <Header/>
            <div className = 'container'>
                <TopTable games={games}></TopTable>
            </div>
        </div>
    );
}

export default TopPage;