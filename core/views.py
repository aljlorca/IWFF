from django.contrib.messages.api import success
from django.core import paginator
from django.http import request
from django.http.response import Http404
from django.shortcuts import render, redirect, get_object_or_404
from .models import  *
from .forms import *
from django.contrib import messages
from django.core.paginator import Paginator
from django.contrib.auth import authenticate,login
from django.db import connection
import cx_Oracle 



# Create your views here.

def home(request):
    productos = producto.objects.all()
    data = {
        'producto': productos
    }
    return render(request, 'core/home2.html', data)

def contacto(request):
    data = {
        'form': ContactoForms()
    }
    if request.method == 'POST':
        formulario = ContactoForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            data["mensaje"] = "contacto guardado"
        else:
            data["form"] = formulario
    return render(request, 'core/Contacto.html',data)

def agregar_producto(request):

    data = {
        'form': AgregarProductoForms()  
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Producto registrado correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: El producto no fue registrado")

    return render(request, 'core/producto/agregar.html', data)
#Funcion listar prodcutos
def listar_productos(request):
    data = {
        'producto':lista_prodcuto()
    }
    return render(request, 'core/producto/listar.html',data)
#Procedimiento listar productos
def lista_prodcuto():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('core_listar_productos', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
def modificar_producto(request, id):
    product = get_object_or_404(producto, id=id)
    data = {
        'form': AgregarProductoForms(instance=product)
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST,instance=product, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Producto modificado correctamente ")
            return redirect(to="listar_producto")
        else:
            data["form"] = formulario
            
    return render(request, 'core/producto/modificar.html', data)
def eliminar_producto(request, id ):
    prod = get_object_or_404(producto, id=id)
    prod.delete()
    messages,success(request, "Producto eliminado correctamente")
    return redirect(to="listar_producto")

#Registro de clientes
def register(request):
    data = {
        'form':RegistroForms()
    }
    if request.method == 'POST':
        formulario = RegistroForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            user = authenticate(username=formulario.cleaned_data["username"],password=formulario.cleaned_data["password1"])
            login(request, user)
            messages.success(request, "Registro exitoso")
            return redirect(to="home")
        data['from'] = formulario
    return render(request, 'registration/register.html', data)

#Utilizacion de procesos de almacenado
#Funcion listar familias
def Familia(request):
    data = {
        'familia':listar_familia()
    }
    return render(request, 'core/familia/listar.html', data)
#funcion de almacenado de familias
def nueva_familia(request):
    data = {

        'familia':agregar_familia

    }

    if request.method == 'POST':
        nombre = request.POST.get('nombre')
        salida = agregar_familia(nombre)
        if salida == 1:
            messages.success(request, " Familia registrada correctamente ")

    return render(request, 'core/familia/agregar.html',data)
#Procedimiento para llamar a las familias
def listar_familia():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('core_familia_listar', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
#Procedimiento para guardar familias
def agregar_familia(nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('core_familia_agregar',[nombre,salida])
    return salida.getvalue()