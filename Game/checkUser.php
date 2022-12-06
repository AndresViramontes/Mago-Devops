<?php
include "dbConnection.php";

try{
    $conn = mysqli_connect($db_servidor, $db_usuario, $db_pass, $db_baseDatos);

	if(!$conn){
		echo'{"codigo":400, "mensaje": "Error al conectar a la Base de datos"}';
	}else{
        if(isset($_POST['usuario']) && isset ($_POST['pass']) ){

            $usuario = $_POST['usuario'];
            $pass = $_POST['pass'];

            $sql = "SELECT * FROM `usuario`WHERE username = '" .$usuario."' AND password = '".$pass."'; ";
            $resultado = $conn -> query($sql);
            if($resultado->num_rows> 0){
                echo'{"codigo":205,"mensaje":"Inicio de sesion correcto","respuesta":"'.$usuario.'"}';
            }else{
                echo'{"codigo":303,"mensaje":"Usuario o la contraseña son incorrectos","respuesta":""}';
            }
        }else{
            echo'{"codigo":405,"mensaje":"Completa todos los campos","respuesta":""}';
        }
    }
}catch (Exepcion $e){
	echo'{"codigo":400,"mensaje":"Error al conectar a la Base de datos","respuesta":""}';
}
?>
