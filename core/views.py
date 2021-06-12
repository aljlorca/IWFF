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
#Home de la pagina
def home(request):
    productos = producto.objects.all() 
    data = {
        'producto': productos,
    }
    return render(request, 'core/home2.html', data)
#formulario de contacto
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
#Productos
#Procedimiento para agregar producto
def agregar_producto(request):

    data = {
        'form': AgregarProductoForms()  
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, "Producto registrado correctamente ")
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
    cursor.callproc('core_productos_listar', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
#Procedimiento para modificar producto
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
#Procedimiento para eliminar producto
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

#Familias
#Funcion listar familias
def listar_familias(request):
    data = {
        'familia':listar_familia()
    }
    return render(request, 'core/familia/listar.html', data)
#funcion de almacenado de familias
def nueva_familia(request):
    data = {
        'form': AgregarFamiliaForms()  
    }
    if request.method == 'POST':
        formulario = AgregarFamiliaForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Familia registrada correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: La Familia no fue registrada")

    return render(request, 'core/familia/agregar.html', data)
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
#Procedimiento para eliminar familia    
def eliminar_familia(request, id ):
    fam = get_object_or_404(familia, id=id)
    fam.delete()
    messages,success(request, "familia eliminado correctamente")
    return redirect(to="listar_familias")
#Procedimiento para modificar familia
def modificar_familia(request, id):
    famil = get_object_or_404(familia, id=id)
    data = {
        'form': AgregarFamiliaForms(instance=famil)
    }
    if request.method == 'POST':
        formulario = AgregarFamiliaForms(data=request.POST,instance=famil)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Familia modificada correctamente ")
            return redirect(to="listar_familias")
        else:
            data["form"] = formulario
            
    return render(request, 'core/familia/modificar.html', data)


#Proveedores 
#Funcion de listado de proveedores
def listar_proveedor (request):
    data = {
        'proveedor':listar_proveedores()
    }
    return render(request,'core/proveedor/listar.html',data)
#Funcion de almacenado de proveedor
def nuevo_proveedor(request):
    data = {
        'form': AgregarProveedorForms()  
    }
    if request.method == 'POST':
        formulario = AgregarProveedorForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Proveedor registrado correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: El proveedor no fue registrado")

    return render(request, 'core/proveedor/agregar.html', data)
#Procedimiento de listado de proveedores
def listar_proveedores():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('core_proveedor_listar', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
#Procedimiento para guardar proveedores
def agregar_proveedor(rut,nombre,telefono,rubro):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('core_proveedor_agregar',[rut,nombre,telefono,rubro,salida])
    return salida.getvalue()
#Procedimiento para eliminar proveedor
def eliminar_proveedor(request, id ):
    prov = get_object_or_404(proveedor, id=id)
    prov.delete()
    messages,success(request, "Proveedor eliminado correctamente")
    return redirect(to="listar_proveedor")
#Procedimiento modificar Proveedor 
def modificar_proveedor(request, id):
    prov = get_object_or_404(familia, id=id)
    data = {
        'form': AgregarProveedorForms(instance=prov)
    }
    if request.method == 'POST':
        formulario = AgregarProveedorForms(data=request.POST,instance=prov)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Proveedor modificada correctamente ")
            return redirect(to="listar_proveedor")
        else:
            data["form"] = formulario
            
    return render(request, 'core/proveedor/modificar.html', data)