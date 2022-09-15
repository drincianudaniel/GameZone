import Header from "../components/Header";
import TopTable from "../components/Tables/TopTable";
import axios from "axios";
import { useEffect, useState } from "react";
import { Container, Divider } from "@mui/material";
import AppPagination from "../components/Pagination/AppPagination";

function TopPage() {
  const [games, setGames] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [pageSize, setPageSize] = useState(10);

  useEffect(() => {
    getTop();
  }, [page]);

  const getTop = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/top/page/${page}/page-size/${pageSize}`
      )
      .then((res) => {
        setGames(res.data.data);
        setNumberOfPages(res.data.totalPages);
      });
  };

  return (
    <div>
      <Header />
      <Container sx={{ marginTop: 4 }} maxWidth="xl">
        {" "}
        <TopTable games={games} />
        <Divider sx={{mb:2}}></Divider>
        <AppPagination
          setPage={setPage}
          numberOfPages={numberOfPages}
          pageSize={pageSize}
        />
      </Container>
    </div>
  );
}

export default TopPage;
