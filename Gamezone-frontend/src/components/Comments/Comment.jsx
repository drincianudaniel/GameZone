import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import MoreMenu from "../Menus/MoreMenu";
import RepliesDialog from "../Replies/RepliesDialog";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Typography } from "@mui/material";
import { Link } from "react-router-dom";
import { useUser } from "../../hooks/useUser";
import CommentService from "../../api/CommentService";
import LoadingBarComponent from "../LoadingComponents/LoadingBar";
import { useState } from "react";
import { Box } from "@mui/system";
import { useConfirm } from "material-ui-confirm";

function Comment(props) {
  const [open, setOpen] = React.useState(false);
  const { user } = useUser();
  const [progress, setProgress] = useState(0);
  const confirm = useConfirm();

  const handleDelete = async () => {
    setProgress(50);
    confirm({ description: "This will permanently delete the comment." })
      .then(() => {
        CommentService.deleteComment(props.comment.id, user.Id)
          .then((response) => {
            props.getComments();
          })
          .catch((err) => console.log(err));
        setProgress(100);
      })
      .catch(() => setProgress(100));
  };

  return (
    <Box>
      <LoadingBarComponent progress={progress} setProgress={setProgress} />
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.comment.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Link
              style={{ textDecoration: "none", color: "inherit" }}
              to={`/profile/${props.comment.userName}/reviews`}
            >
              <Typography
                sx={{
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
            <Typography
              sx={{ fontSize: 15, textAlign: "left", color: "gray", ml: 1 }}
            >
              {moment(
                convertUTCDateToLocalDate(new Date(props.comment.createdAt))
              ).fromNow()}
            </Typography>
          </Box>
          <Typography sx={{ textAlign: "left", mt: 1 }}>
            {props.comment.content}
          </Typography>
          <RepliesDialog
            open={open}
            setOpen={setOpen}
            commentId={props.comment.id}
            comment={props.comment}
          />
        </Grid>
        <Grid>
          {(user.UserName === props.comment.userName || user.IsAdmin) && (
            <MoreMenu handleDelete={handleDelete} />
          )}
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </Box>
  );
}

export default Comment;
