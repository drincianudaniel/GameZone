import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import GamePagination from "../Pagination/GamePagination";
import Comment from "./Comment";
import PostCommentForm from "../Forms/PostCommentForm";
import { Box, Typography } from "@mui/material";
import SpinningLoading from "../LoadingComponents/SpinningLoading";
import { useUser } from "../../hooks/useUser";
import { Link } from "react-router-dom";
function Comments() {
  const [comments, setComments] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const params = useParams();
  const { user } = useUser();

  useEffect(() => {
    getComments();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  const getComments = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/comments/game/${
          params.id
        }/page/${page}/page-size/${4}`
      )
      .then((res) => {
        setComments(res.data.data);
        setNumberOfPages(res.data.totalPages);
        setIsLoading(false);
      });
  };

  return (
    <>
      <Box sx={{ mt: { xs: 2, sm: 2, lg: 0 } }}>
        {isLoading ? (
          <SpinningLoading />
        ) : comments.length > 0 ? (
          comments.map((comment) => {
            return (
              <Comment
                key={comment.id}
                comment={comment}
                getComments={getComments}
              />
            );
          })
        ) : (
          <Typography sx={{ marginBottom: 2 }}>
            No comments yet. Please add a comment.
          </Typography>
        )}
        {user.IsLoggedIn && (
          <PostCommentForm id={params.id} getComments={getComments} />
        )}
        {!user.IsLoggedIn && (
          <Typography sx={{ mb: 2 }}>
            You have to be{" "}
            <Link to={"/login"}>
              <Typography sx={{ display: "inline", color: "primary.main" }}>
                logged in
              </Typography>
            </Link>{" "}
            to post a comment.
          </Typography>
        )}
        <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
      </Box>
    </>
  );
}

export default Comments;
