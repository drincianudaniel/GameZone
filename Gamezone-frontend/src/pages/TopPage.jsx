import Header from "../components/Header";
import TopTable from "../components/Tables/TopTable";
import axios from "axios";
import { useEffect, useState } from "react";
import { Container, Divider } from "@mui/material";
import AppPagination from "../components/Pagination/AppPagination";
import SpinningLoading from "../components/LoadingComponents/SpinningLoading";

function TopPage() {
  const [games, setGames] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);

  useEffect(() => {
    const getTop = async () => {
      await axios
        .get(
          `${
            process.env.REACT_APP_SERVERIP
          }/games/top/page/${page}/page-size/${10}`
        )
        .then((res) => {
          setGames(res.data.data);
          setNumberOfPages(res.data.totalPages);
          setIsLoading(false);
        });
    };
    getTop();
  }, [page]);

  return (
    <div>
      <Header />
      {isLoading ? (
        <SpinningLoading />
      ) : (
        <Container sx={{ marginTop: 4 }} maxWidth="xl">
          {" "}
          <TopTable games={games} page={page} />
          <Divider sx={{ mb: 2 }}></Divider>
          <AppPagination setPage={setPage} numberOfPages={numberOfPages} />
        </Container>
      )}
    </div>
  );
}

export default TopPage;
