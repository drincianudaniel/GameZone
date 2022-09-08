import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import IconButton from "@mui/material/IconButton";
import ClearIcon from "@mui/icons-material/Clear";
import axios from "axios";

const imgLink =
  "https://images.pexels.com/photos/1681010/pexels-photo-1681010.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";

function convertUTCDateToLocalDate(date) {
  var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);

  var offset = date.getTimezoneOffset() / 60;
  var hours = date.getHours();

  newDate.setHours(hours - offset);

  return newDate;
}

function Reply(props){

    const deleteReply = async () => {
        await axios
          .delete(`${process.env.REACT_APP_SERVERIP}/replies/${props.reply.id}`)
          .then((response) => {
            props.getReplies();
          })
          .catch((err) => console.log(err));
      };

    return(
        <div style={{ padding: 14 }} className="App">
        <Grid container wrap="nowrap" spacing={2}>
          <Grid item>
            <Avatar alt="Remy Sharp" src={imgLink} />
          </Grid>
          <Grid justifyContent="left" item xs zeroMinWidth>
            <h4 style={{ margin: 0, textAlign: "left" }}>
              {props.reply.username}
            </h4>
            <p style={{ textAlign: "left" }}>{props.reply.content}</p>
            <p style={{ textAlign: "left", color: "gray" }}>
              {moment(
                convertUTCDateToLocalDate(new Date(props.reply.createdAt))
              ).fromNow()}
            </p>
          </Grid>
          <Grid>
            <IconButton aria-label="Delete" onClick={deleteReply}>
              <ClearIcon></ClearIcon>
            </IconButton>
          </Grid>
        </Grid>
        <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
      </div>
    )
}

export default Reply;