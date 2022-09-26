import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import RepliesDialog from "../Replies/RepliesDialog";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Typography } from "@mui/material";
import { Link } from "react-router-dom";
import { useUser } from "../../hooks/useUser";
import CommentService from "../../api/CommentService";

function Comment(props) {
  const [open, setOpen] = React.useState(false);
  const { user } = useUser();

  const handleDelete = async () => {
    await axios
      CommentService.deleteComment(props.comment.id)
      .then((response) => {
        props.getComments();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: { lg: 14, xs: 1 } }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.comment.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <Link
            style={{ textDecoration: "none", color: "inherit" }}
            to={`/profile/${props.comment.userName}`}
          >
            <Typography
              sx={{
                margin: 0,
                textAlign: "left",
                fontWeight: "bold",
                cursor: "pointer",
                "&:hover": {
                  color: "primary.main",
                },
              }}
            >
              {props.comment.userName}
            </Typography>
          </Link>

          <p style={{ textAlign: "left" }}>{props.comment.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.comment.createdAt))
            ).fromNow()}
          </p>
          <RepliesDialog
            open={open}
            setOpen={setOpen}
            commentId={props.comment.id}
            comment={props.comment}
          />
        </Grid>
        <Grid>
          {((user.UserName === props.comment.userName) || (user.IsAdmin)) && (
            <MoreMenu handleDelete={handleDelete} />
          )}
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Comment;
