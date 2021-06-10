# Generated by Django 3.2.3 on 2021-06-10 19:07

import datetime
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('core', '0006_factura'),
    ]

    operations = [
        migrations.CreateModel(
            name='boleta',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('fecha', models.DateField(default=datetime.datetime.today)),
                ('canitdad_producto', models.IntegerField()),
                ('total', models.IntegerField()),
                ('producto', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='core.producto')),
            ],
        ),
    ]