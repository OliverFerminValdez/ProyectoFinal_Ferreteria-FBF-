function Notificar(mensaje) {

    if (Notification.permission !== "granted")
        Notification.requestPermission();
    else {
        var notification = new Notification(
            "Ferreteria FBF",
            {
                icon: "Resources/FBF.png",
                body: mensaje
            }
        );
    }


}