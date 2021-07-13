from collections import namedtuple
from django.urls import path
from django.urls.conf import include
from requests.models import parse_header_links
from .views import *    
from django.contrib import admin

urlpatterns = [
    path('',home, name='home'), 
    #contacto
    path('contacto/', contacto, name="contacto"),
    #producto
    path('agregarproducto/', agregar_producto, name="agregar_producto"),
    path('listarproducto/', listar_productos, name="listar_producto"),
    path('modificarproducto/<id>/', modificar_producto, name="modificar_producto"),
    path('eliminarproducto/<id>/', eliminar_producto, name="eliminar_producto"),
    #registro
    path('register/', register, name="register"),
    #familia
    path('listar_familias/', listar_familias, name='listar_familias' ),
    path('nueva_familia/', nueva_familia, name='nueva_familia'),
    path('modificarfamilia/<id>/', modificar_familia, name="modificar_familia"),
    path('eliminarfamilia/<id>/', eliminar_familia, name="eliminar_familia"),
    #Proveedor
    path('listar_proveedor/', listar_proveedor, name='listar_proveedor' ),
    path('nuevo_proveedor/', nuevo_proveedor, name='nuevo_proveedor'),
    path('modificarproveedor/<id>/', modificar_proveedor, name="modificar_proveedor"),
    path('eliminarproveedor/<id>/', eliminar_proveedor, name="eliminar_proveedor"),
    #Carrito
    path('carrito/', carrito, name='carrito'),
]