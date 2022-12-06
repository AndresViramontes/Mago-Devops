<?php
include "dbConnection.php";

try{
    $conn = mysqli_connect($db_servidor, $db_usuario, $db_pass, $db_baseDatos);

	if(!$conn){
		echo'{"codigo":400, "mensaje": "Error al conectar a la Base de datos"}';
	}else{
        if(isset($_POST['usuario']) && isset ($_POST['pass'])){

        
            $usuario = $_POST['usuario'];
            $pass = $_POST['pass'];
            if($usuario!=""&$pass!="")
            {
                $sql = "SELECT * FROM `usuario`WHERE username = '" .$usuario."'; ";
                $resultado = $conn -> query($sql);
            if($resultado->num_rows> 0){
                echo'{"codigo":301, "mensaje": "Usuario Ya registrado","respuesta": ""}';
            }else{
                $sql = "INSERT INTO `usuario`(`idUsuario`, `username`, `password`) VALUES (NULL, '".$usuario."', '".$pass."');";

                if($conn -> query($sql) === TRUE){
                echo'{"codigo": 201, "mensaje": "Usuario registrado correctamente", "respuesta": "'.$usuario.'"}';
                }else{
                echo'{"codigo": 401,"mensaje": "Error Usuario no pudo ser creado", "respuesta": ""}';
                } 
            }
            }else{
                echo'{"codigo": 402, "mensaje": "Error faltan datos para la creacion del usuario", "respuesta": ""}';
            }
            
        }else{
            echo'{"codigo": 407, "mensaje": "Los campos no pueden estar vacios", "respuesta": ""}';
        }
    }
}catch (Exepcion $e){
	echo'{"codigo": 400, "mensaje": "Error al conectar a la Base de datos", "respuesta": ""}';
}
?>

