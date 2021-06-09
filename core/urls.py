from collections import namedtuple
from django.urls import path
from django.urls.conf import include
from .views import *    
from django.contrib import admin

urlpatterns = [
    path('',home, name='home'), 
    path('Contacto/', contacto, name="contacto"),
    path('agregarproducto/', agregar_producto, name="agregar_producto"),
    path('listarproducto/', listar_productos, name="listar_producto"),
    path('modificarproducto/<id>/', modificar_producto, name="modificar_producto"),
    path('eliminarproducto/<id>/', eliminar_producto, name="eliminar_producto"),
    path('register/', register, name="register"),
    path('listar_familias/', listar_familias, name='listar_familias' ),
    path('nueva_familia/', nueva_familia, name='nueva_familia')

]