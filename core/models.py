from django.db import models
from django.db.models.base import ModelState
from django.db.models.expressions import Case
from django.db.models.fields import BooleanField, CharField, NullBooleanField

#Create your models here

class familia(models.Model):
    nombre = models.CharField(max_length=50)

    def __str__(self):
        return self.nombre

class proveedor(models.Model):
    rut = models.IntegerField()
    nombre = models.TextField()
    telefono = models.IntegerField()
    rubro = models.TextField()


    def __str__(self):
        return self.nombre      


class producto(models.Model):
    id = models.CharField(max_length=17, primary_key=True)
    nombre = models.CharField(max_length=30)
    descripcion = models.TextField(max_length=300)
    precio = models.IntegerField() 
    familia = models.ForeignKey(familia, on_delete=models.PROTECT)
    vencimiento = models.DateField()
    stock = models.IntegerField()
    stock_critico = models.IntegerField()
    proveedor = models.ForeignKey(proveedor, on_delete=models.PROTECT)
    imagen = models.ImageField(upload_to='productos', null=True)

    def __str__(self):
        return self.nombre

class cargo(models.Model):
    nombre = models.CharField(max_length=20)
    descripcio = models.TextField()

class persona(models.Model):
    rut = models.IntegerField()
    nombre = models.TextField()
    telefono = models.IntegerField()
    cargo = models.ForeignKey(cargo, on_delete=models.PROTECT)
    
    def __str__(self):
        return self.nombre



opciones_consultas = [

    [0, 'Consulta'],
    [1, 'Reclamo'],
    [2, 'Sugerencia'],
    [3, 'Felicitaciones'],
    [4, 'Solicitud de registro'],

]

class contacto(models.Model):

    nombre = models.CharField(max_length=50)
    correo = models.EmailField()
    tipo_consulta = models.IntegerField(choices=opciones_consultas)
    mensaje = models.TextField()
    avisos = BooleanField()
    rut = models.IntegerField()
    def __str__(self):
        return self.nombre
