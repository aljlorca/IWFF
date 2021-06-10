from typing import ClassVar
from django import forms
from django.contrib import auth
from django.db import models
from django.db.models import fields
from django.forms import widgets    
from .models import contacto, familia, producto
from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.models import User

class ContactoForms(forms.ModelForm):
    
    class Meta:
        model = contacto
        #Fiedls detalla todos los datos para el formulario como se necesitan todos se usa __all__
        fields = '__all__'

#widget para fecha de vencimiento de producto


class AgregarProductoForms(forms.ModelForm):
    class Meta:
        model = producto
        fields = '__all__'
        widgets = {
        "vencimiento": forms.SelectDateWidget() 
        }

class AgregarFamiliaForms(forms.ModelForm):
    class Meta:
        model = familia
        fields = '__all__'


class RegistroForms(UserCreationForm):
    pass

