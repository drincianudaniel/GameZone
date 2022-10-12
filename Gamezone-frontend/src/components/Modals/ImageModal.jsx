import { Fade, Modal, Backdrop } from "@mui/material";

// const useStyles = makeStyles((theme) => ({
//     modal: {
//       display: "flex",
//       alignItems: "center",
//       justifyContent: "center",
//       "&:hover": {
//         backgroundcolor: "red"
//       }
//     },
//     img: {
//       outline: "none"
//     }
//   }));

export default function ImageModal(props) {
  // const classes = useStyles();

  const handleClose = () => {
    props.setOpen(false);
  };

  return (
    <Modal
      sx={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        "&:hover": {
          backgroundcolor: "red",
        },
      }}
      open={props.open}
      onClose={handleClose}
      closeAfterTransition
      BackdropComponent={Backdrop}
      BackdropProps={{
        timeout: 500,
      }}
    >
      <Fade in={props.open} timeout={500}>
        <img
          src={props.image}
          alt="asd"
          style={{
            maxHeight: "90%",
            maxWidth: "90%",
            outline: "none",
            zIndex: "100",
          }}
        />
      </Fade>
    </Modal>
  );
}
